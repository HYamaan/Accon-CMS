import React, {useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";

const AddWhyChooseUs = (props) => {
    const router = useRouter();
    const [heading, setHeading] = useState("");
    const [photo, setPhoto] = useState("/photo-1.jpg");
    const [content, setContentt] = useState("");

    const handleSubmit = () => {
        console.log(heading, photo, content);
        // İsteği göndermek veya başka işlemler yapmak için burada kod ekleyin.
    };

    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header mb-3">
                    <div className="board-header">
                        <FaArrowAltCircleRight />
                        <h2>{props.heading ? "Edit Why Choose Us":"Add Why Choose Us"}</h2>
                    </div>
                    <div
                        className="view-border-header__add-view"
                        onClick={() => router.push("/admin//why-choose-us")}
                    >
                        <FaPlus />
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">

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
