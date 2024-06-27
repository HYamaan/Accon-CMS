import React, { useState } from 'react';
import { useRouter } from "next/router";
import { FaArrowAltCircleRight, FaPlus } from "react-icons/fa";
import { LazyLoadImage } from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";

const AddPhotoGallery = () => {
    const router = useRouter();
    const [caption, setCaption] = useState("");
    const [photo, setPhoto] = useState("/photo-1.jpg");
    const [showOnHome, setShowOnHome] = useState(true);

    const handleSubmit = () => {
        console.log(caption, photo, showOnHome);
        // İsteği göndermek veya başka işlemler yapmak için burada kod ekleyin.
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
                         onClick={() => router.push("/admin/photo-gallery")}
                    >
                        <FaPlus />
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="panel-box-select">
                            <span className="col-md-2">Photo Caption *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={caption}
                                    onChange={(e) => setCaption(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Existing Photo</span>
                            <div className="col-md-10">
                                <div className="panel-website-icon-show">
                                    <LazyLoadImage src={photo} />
                                </div>
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">New Photo</span>
                            <div className="col-md-10">
                                <div className="panel-website-icon-show">
                                    <OneFileUpload file={photo} setFile={setPhoto} />
                                </div>
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Show on home? *</span>
                            <div className="col-md-10">
                                <select
                                    value={showOnHome}
                                    onChange={(e) => setShowOnHome(e.target.value === "true")}
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

export default AddPhotoGallery;
