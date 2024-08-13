import React, {useEffect, useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import WYSIWYG from "@/Components/WYSIWYG/WYSIWYG";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";

const AddPortfolio = (props) => {
    const router = useRouter();
    const [name, setName] = useState("");
    const [existPhoto, setExistPhoto] = useState("");
    const [photo, setPhoto] = useState("/photo-1.jpg");
    const [shortContent, setShortContent] = useState("");
    const [content, setContentt] = useState("");
    const [clientName, setClientName] = useState("");
    const [clientCompany, setClientCompany] = useState("");
    const [startDate, setStartDate] = useState("");
    const [endDate, setEndDate] = useState("");
    const [website, setWebsite] = useState("");
    const [cost, setCost] = useState("");
    const [clientComment, setClientComment] = useState("");
    const [category, setCategory] = useState("");

    const [featuredPhoto, setFeaturedPhoto] = useState("/portfolio-1.jpg");

    const [bannerPhoto, setBannerPhoto] = useState("");

    const [metaTitle,setMetaTitle] = useState("");
    const [metaDescription,setMetaDescription] = useState("");
    const [metaKeyword,setMetaKeyword] = useState("");


    const handleSubmit = () => {
        console.log(name, photo, content);
        // İsteği göndermek veya başka işlemler yapmak için burada kod ekleyin.
    };

    const [photos, setPhotos] = useState([]);

    const handleAddPhoto = (photo) => {
        setPhotos([...photos, photo]);
    };

    const handleRemovePhoto = (index) => {
        const newPhotos = photos.filter((_, i) => i !== index);
        setPhotos(newPhotos);
    };

    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header mb-3">
                    <div className="board-header">
                        <FaArrowAltCircleRight />
                        <h2>{props.name ? "Edit Portfolio":"Add Portfolio"}</h2>
                    </div>
                    <div
                        className="view-border-header__add-view"
                        onClick={() => router.push("/admin/portfolio")}
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
                            <span className="col-md-2">Client Name</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={clientName}
                                    onChange={(e) => setClientName(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Client Company</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={clientCompany}
                                    onChange={(e) => setClientCompany(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Start Date</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={startDate}
                                    onChange={(e) => setStartDate(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">End Date</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={endDate}
                                    onChange={(e) => setEndDate(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Website</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={website}
                                    onChange={(e) => setWebsite(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Cost</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={cost}
                                    onChange={(e) => setCost(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Client Comment</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={clientComment}
                                    onChange={(e) => setClientComment(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Select Category *</span>
                            <div className="col-md-10">
                                <select
                                    value={category}
                                    onChange={(e) => setCategory(e.target.value)}
                                >
                                    <option value="Busines">Busines</option>
                                    <option value="Corporate">Corporate</option>
                                    <option value="Enginnering">Engineering</option>

                                </select>
                            </div>
                        </div>

                        <UploadLogoComponent
                            logoFile={featuredPhoto}
                            setLogoFile={setFeaturedPhoto}
                            title="Featured Photo"
                        />
                        <div className="tab-content">
                        <h3 className="panel-website-icon">Other Photos</h3>
                        {photos.length > 0 && (
                            <div className="panel-box-select">
                                <span className="col-md-2">Existing Photos</span>
                                <div className="col-md-10 row">
                                    {photos.map((photo, index) => (
                                        <div key={index} className="panel-website-icon-show">
                                            <LazyLoadImage
                                                src={`/${photo.name}`}
                                                effect="blur"
                                            />
                                            <div
                                                className="ms-3 px-3 py-2 rounded-2 bg-danger text-white"
                                                onClick={() => handleRemovePhoto(index)}
                                                style={{ cursor: 'pointer' }}
                                            >
                                                X
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            </div>
                        )}
                        <div className="panel-box-select">
                            <span className="col-md-2">New Photo</span>
                            <div className="col-md-10">
                                <div className="panel-website-icon-show">
                                    <OneFileUpload
                                        file={null}
                                        setFile={(photo) => {
                                            handleAddPhoto(photo);
                                        }}
                                    />
                                </div>
                            </div>
                        </div>
                    </div>

                        <UploadLogoComponent
                            logoFile={bannerPhoto}
                            setLogoFile={setBannerPhoto}
                            title="Banner Photo"
                        />

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

export default AddPortfolio;
