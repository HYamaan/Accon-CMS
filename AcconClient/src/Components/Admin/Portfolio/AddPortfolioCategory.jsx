import React, {useEffect, useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import axios from "axios";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";
import {toast} from "react-toastify";

const AddPortfolioCategory = () => {
    const router = useRouter();
    const [name, setName] = useState("");
    const [status, setStatus] = useState(true);

    useEffect(() => {
        const getRoutuerSlider = async () => {
            var id = router.query.Id;
            if (id !== undefined) {
                try {
                    var response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Portfolio/GetEditPortfolioCategory?Id=${id}`);

                    if (response.data.succeeded) {
                        const dataValues = response.data.data;
                        setName(dataValues.title);
                        setStatus(dataValues.isActive);
                    }
                } catch (e) {
                    console.error(e);
                }
            }
        }
        getRoutuerSlider();
    }, [router.query.Id]);
    const handleSubmit = async (e) => {
        e.preventDefault();
        const values = {
            "title": name,
            "isActive": status
        };
        if (router.query.Id !== undefined) {
            values.id = router.query.Id;
        }

        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Portfolio/AddPortfolioCategory`, values, {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (response.data.succeeded) {
                toast.success(`${name} category updated successfully`);
                router.push('/admin/portfolio-category');
            } else {
                toast.error(`Error updating ${name} category`);
            }
        } catch (error) {
            console.error(`Error updating ${name} category`, error);
        }
    }

    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header mb-3">
                    <div className="board-header">
                        <FaArrowAltCircleRight />
                        <h2>Add Slider</h2>
                    </div>
                    <div className="view-border-header__add-view"
                         onClick={() => router.push("/admin/portfolio-category")}
                    >
                        <FaPlus />
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="panel-box-select">
                            <span className="col-md-2">Category Name *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={name}
                                    onChange={(e) => setName(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Status *</span>
                            <div className="col-md-10">
                                <select
                                    value={status}
                                    onChange={(e) => setStatus(e.target.value === "true")}
                                >
                                    <option value="true">Yes</option>
                                    <option value="false">No</option>
                                </select>
                            </div>
                        </div>
                        <div className="panel-box-select ps-md-3">
                            <div className="col-md-2"></div>
                            <div className="col-md-10">
                                <button onClick={handleSubmit}
                                        className="secondary-button panel-website-icon-show__button">Update
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default AddPortfolioCategory;
