import React, { useState } from 'react';
import { useRouter } from 'next/router';
import { FaArrowAltCircleRight, FaPlus } from 'react-icons/fa';
import { LazyLoadImage } from 'react-lazy-load-image-component';
import OneFileUpload from '@/Components/Ui/OneFileUpload';

const AddTestimonial = (props) => {
    const router = useRouter();
    const [name, setName] = useState("");
    const [photo, setPhoto] = useState("/photo-1.jpg");
    const [designationName, setDesignationName] = useState("");
    const [company, setCompany] = useState("");
    const [comment, setComment] = useState("");

    const handleSubmit = () => {
        console.log(name, photo, designationName, company, comment);
        // İsteği göndermek veya başka işlemler yapmak için burada kod ekleyin.
    };

    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header mb-3">
                    <div className="board-header">
                        <FaArrowAltCircleRight />
                        <h2>{props.name ? "Edit Testimonial":"Add Testimonial"}</h2>
                    </div>
                    <div
                        className="view-border-header__add-view"
                        onClick={() => router.push("/admin/team-member")}
                    >
                        <FaPlus />
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="panel-box-select">
                            <span className="col-md-2">Name *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={name}
                                    onChange={(e) => setName(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Designation *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={designationName}
                                    onChange={(e) => setDesignationName(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Company *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={company}
                                    onChange={(e) => setCompany(e.target.value)}
                                />
                            </div>
                        </div>
                        {props?.existPhoto && (
                            <div className="panel-box-select">
                                <span className="col-md-2">Existing Photo</span>
                                <div className="col-md-10">
                                    <div className="panel-website-icon-show">
                                        <LazyLoadImage src={photo} />
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
                            <span className="col-md-2">Comment *</span>
                            <div className="col-md-10">
                                <textarea
                                    rows="4"
                                    value={comment}
                                    onChange={(e) => setComment(e.target.value)}
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

export default AddTestimonial;
