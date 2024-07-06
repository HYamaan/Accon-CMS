import React, {useEffect, useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import WYSIWYG from "@/Components/WYSIWYG/WYSIWYG";
import axios from "axios";
import {toast} from "react-toastify";
import {VisibilityPlaceEnum} from "@/data/enum/VisibilityPlaceEnum";

const AddFaq = () => {
    const router = useRouter();
    const [faqTitle, setFaqTitle] = useState("");
    const [faqContent, setFaqContent] = useState("");
    const [visiblePlace, setVisiblePlace] = useState(1);

    useEffect(() => {
        const getRouterSlider = async () => {
            const { id } = router.query;
            if (id !== undefined) {
                try {
                    const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Faq/GetFaqEdit?Id=${id}`);
                    console.log("response", response.data)
                    if (response.data.succeeded) {
                        const dataValues = response.data.data;
                        setFaqTitle(dataValues.title);
                        setFaqContent(dataValues.content);
                        setVisiblePlace(dataValues.visiblePage);
                    }
                } catch (e) {
                    console.error(e);
                }
            }
        }
        getRouterSlider();
    }, [router.query.id]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        const values = {
            "Title": faqTitle,
            "content": faqContent,
            "VisiblePlace": visiblePlace
        };
        if (router.query.id !== undefined) {
            values.id = router.query.id;
        }

        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Faq/UpdateFaq`, values, {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (response.data.succeeded) {
                toast.success(`${faqTitle} service updated successfully`);
                router.push('/admin/faq');
            } else {
                toast.error(`Error updating ${faqTitle} service`);
            }
        } catch (error) {
            console.error(`Error updating ${faqTitle} service`, error);
        }
    }

    return (
        <div className="content-wrapper">
            <div className="view-border-header mb-3">
                <div className="board-header">
                    <FaArrowAltCircleRight />
                    <h2>Add Faq</h2>
                </div>
                <div className="view-border-header__add-view"
                     onClick={() => router.push("/admin/faq")}
                >
                    <FaPlus />
                    <span>View All</span>
                </div>
            </div>
            <div className="panel-box">
                <div className="panel-box-body">
                    <div className="panel-box-select">
                        <span className="col-md-2">FAQ Title *</span>
                        <div className="col-md-10">
                            <input
                                type="text"
                                value={faqTitle}
                                onChange={(e) => setFaqTitle(e.target.value)}
                            />
                        </div>
                    </div>
                    <div className="panel-box-select">
                        <span className="col-md-2">FAQ Content *</span>
                        <div className="col-md-10">
                            <WYSIWYG
                                text={faqContent}
                                setText={setFaqContent}
                                className="w-75"
                            />
                        </div>
                    </div>
                    <div className="panel-box-select">
                        <span className="col-md-2">Visible Place *</span>
                        <div className="col-md-10">
                            <select
                                value={visiblePlace}
                                onChange={(e) => setVisiblePlace(Number(e.target.value))}
                            >
                                {Object.entries(VisibilityPlaceEnum).map(([key, value]) => (
                                    <option key={key} value={key}>{value}</option>
                                ))}
                            </select>
                        </div>
                    </div>
                    <div className="panel-box-select ps-md-3">
                        <div className="col-md-2"></div>
                        <div className="col-md-10">
                            <button onClick={handleSubmit}
                                    className="secondary-button panel-website-icon-show__button">
                                Update
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default AddFaq;
