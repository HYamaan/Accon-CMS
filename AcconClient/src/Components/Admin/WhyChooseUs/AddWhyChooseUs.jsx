import React, {useEffect, useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import axios from "axios";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";
import {toast} from "react-toastify";

const AddWhyChooseUs = () => {
    const router = useRouter();
    const [heading, setHeading] = useState("");
    const [photo, setPhoto] = useState("");
    const [existPhoto, setExistPhoto] = useState("");
    const [content, setContent] = useState("");

    useEffect(() => {
        const getRoutuerSlider = async () => {
            var id = router.query.Id;
            if (id !== undefined) {
                try {
                    var response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/WhyChooseUs/GetEditWhyChoose?Id=${id}`);
                    if (response.data.succeeded) {
                        const dataValues = response.data.data;
                        setHeading(dataValues.title);
                        setContent(dataValues.content);
                        setExistPhoto(`/${dataValues.image}`);
                    }
                } catch (e) {
                    console.error(e);
                }
            }
        }
        getRoutuerSlider();
    }, [router.query.Id]);

    const handleSubmit =  async (e) => {
        e.preventDefault();
        const formData = new FormData();
        router.query.Id !== undefined && formData.append('Id', router.query.Id);

        formData.append('Title', heading);
        formData.append('Content', content);
        photo && formData.append('Photo', photo);

        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/WhyChooseUs/UpdateChooseUs`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            if (response.data.succeeded) {
                toast.success('Why choose up updated successfully');
                router.push('/admin/why-choose-us');
            } else {
                toast.error(`Error updating ${name} why choose up`);
            }
        } catch (error) {
            toast.error(`Error updating ${name} why choose up`, error);
            console.error(`Error updating ${name} why choose up`, error);
        }
    }

    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header mb-3">
                    <div className="board-header">
                        <FaArrowAltCircleRight />
                        <h2>{router.query.Id ? "Edit Why Choose Us":"Add Why Choose Us"}</h2>
                    </div>
                    <div
                        className="view-border-header__add-view"
                        onClick={() => router.push("/admin/why-choose-us")}
                    >
                        <FaPlus />
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">

                        {existPhoto && (
                            <div className="panel-box-select">
                                <span className="col-md-2">Existing Photo</span>
                                <div className="col-md-10">
                                    <div className="panel-website-icon-show">
                                        <LazyLoadImage src={existPhoto} />
                                    </div>
                                </div>
                            </div>
                        )}
                        <div className="panel-box-select">
                            <span className="col-md-2">New Photo</span>
                            <div className="col-md-10">
                                <div className="panel-website-icon-show">
                                    <OneFileUpload file={photo} setFile={setPhoto} />
                                </div>
                            </div>
                        </div>

                        <div className="panel-box-select">
                            <span className="col-md-2">Heading *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={heading}
                                    onChange={(e) => setHeading(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Content *</span>
                            <div className="col-md-10">
                                <textarea
                                    rows="4"
                                    value={content}
                                    onChange={(e) => setContent(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select ps-md-3">
                            <div className="col-md-2"></div>
                            <div className="col-md-10">
                                <button
                                    onClick={handleSubmit}
                                    className="secondary-button panel-website-icon-show__button"
                                >
                                    Update
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default AddWhyChooseUs;
