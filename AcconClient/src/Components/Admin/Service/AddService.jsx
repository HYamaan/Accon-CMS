import React, {useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import WYSIWYG from "@/Components/WYSIWYG/WYSIWYG";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";

const AddService = (props) => {
    const router = useRouter();
    const [name, setName] = useState("");

    const [shortContent, setShortContent] = useState("");
    const [content, setContentt] = useState("");
    const [photo, setPhoto] = useState("/photo-1.jpg");
    const [banner, setBanner] = useState("/photo-1.jpg");


    const [metaTitle,setMetaTitle] = useState("");
    const [metaDescription,setMetaDescription] = useState("");
    const [metaKeyword,setMetaKeyword] = useState("");


    const handleSubmit = () => {
        console.log(name, photo, content);
        // İsteği göndermek veya başka işlemler yapmak için burada kod ekleyin.
    };




    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header mb-3">
                    <div className="board-header">
                        <FaArrowAltCircleRight />
                        <h2>{props.name ? "Edit Service":"Add Service"}</h2>
                    </div>
                    <div
                        className="view-border-header__add-view"
                        onClick={() => router.push("/admin/service")}
                    >
                        <FaPlus />
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="panel-box-select">
                            <span className="col-md-2">Heading *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={name}
                                    onChange={(e) => setName(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Short Content *</span>
                            <div className="col-md-10">
                                <textarea
                                    rows="4"
                                    value={shortContent}
                                    onChange={(e) => setShortContent(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Content *</span>
                            <div className="col-md-10">
                                <WYSIWYG
                                    text={content}
                                    setText={setContentt}
                                    className="w-75"
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Photo *</span>
                            <div className="col-md-10">
                                <OneFileUpload file={photo}
                                               setFile={setPhoto}
                                               propsClass={"border-0"}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Banner *</span>
                            <div className="col-md-10">
                                <OneFileUpload file={banner}
                                               setFile={setBanner}
                                               propsClass={"border-0"}
                                />
                            </div>
                        </div>


                        <div className="tab-content">
                            <h3 className="panel-website-icon">
                                SEO INFORMATION
                            </h3>
                            <div className="panel-box-select">
                                <span className="col-md-2 ">Existing Photo</span>
                                <div className="col-md-10">
                                    <input
                                        type="text"
                                        value={metaTitle}
                                        onChange={(e) => setMetaTitle(e.target.value)}
                                    />
                                </div>
                            </div>
                            <div className="panel-box-select">
                                <span className="col-md-2 ">Meta Keyword</span>
                                <div className="col-md-10">
                                    <textarea
                                        rows="4"
                                        value={metaKeyword}
                                        onChange={(e) => setMetaKeyword(e.target.value)}
                                    />
                                </div>
                            </div>
                            <div className="panel-box-select">
                                <span className="col-md-2 ">Meta Description</span>
                                <div className="col-md-10">
                                    <textarea
                                        rows="4"
                                        value={metaDescription}
                                        onChange={(e) => setMetaDescription(e.target.value)}
                                    />
                                </div>
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

export default AddService;
