import React, {useEffect, useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import WYSIWYG from "@/Components/WYSIWYG/WYSIWYG";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import axios from "axios";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";
import {toast} from "react-toastify";

const AddService = () => {
    const router = useRouter();
    const [isPublished, setIsPublished] = useState(false);
    const [name, setName] = useState("");

    const [shortContent, setShortContent] = useState("");
    const [content, setContentt] = useState("");
    const [photo, setPhoto] = useState("/photo-1.jpg");
    const [banner, setBanner] = useState("/photo-1.jpg");

    const [existingPhoto, setExistingPhoto] = useState(null);
    const [existingBanner, setExistingBanner] = useState(null)

    const [metaTitle, setMetaTitle] = useState("");
    const [metaDescription, setMetaDescription] = useState("");
    const [metaKeyword, setMetaKeyword] = useState("");


    useEffect(() => {
        const getRoutuerSlider = async () => {
            var id = router.query.Id;
            if (id !== undefined) {
                try {
                    var response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Service/GetServiceEdit?Id=${id}`);
                    if (response.data.succeeded) {
                        const dataValues = response.data.data;
                        setName(dataValues.heading);
                        setShortContent(dataValues.shortContent);
                        setContentt(dataValues.content);
                        setExistingPhoto(`/${dataValues.photo}`);
                        setExistingBanner(`/${dataValues.banner}`);
                        setIsPublished(dataValues.isPublished)

                        setMetaTitle(dataValues.metaTitle);
                        setMetaDescription(dataValues.metaDescription);
                        setMetaKeyword(dataValues.metaKeywords);
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

        formData.append('Heading', name);
        formData.append('ShortContent', shortContent);
        formData.append('Content', content);
        formData.append('IsPublished', isPublished);
        formData.append('MetaTitle', metaTitle);
        formData.append('MetaDescription', metaDescription);
        formData.append('MetaKeywords', metaKeyword);
        formData.append('Photo', photo);
        formData.append('Banner', banner);
        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Service/UpdateService`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            if (response.data.succeeded) {
                toast.success('Slider updated successfully');
                router.push('/admin/service');
            } else {
                toast.error(`Error updating ${name} service`);
            }
        } catch (error) {
            console.error(`Error updating ${name} service`, error);
        }
    }

    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header mb-3">
                    <div className="board-header">
                        <FaArrowAltCircleRight/>
                        <h2>{router.query.Id ? "Edit Service" : "Add Service"}</h2>
                    </div>
                    <div
                        className="view-border-header__add-view"
                        onClick={() => router.push("/admin/service")}
                    >
                        <FaPlus/>
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="panel-box-select">
                            <span className="col-md-2">Published *</span>
                            <div className="col-md-10">
                                <input
                                    type="checkbox"
                                    value={isPublished}
                                    onChange={(e) => setIsPublished(!isPublished)}
                                />
                            </div>
                        </div>
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
                        {
                            existingPhoto !== null && <div className="panel-box-select">
                                <span className="col-md-2">Existing Photo</span>
                                <div className="col-md-10">
                                    <div className="panel-website-icon-show">
                                        <LazyLoadImage
                                            src={existingPhoto}
                                            effect="blur"
                                        />
                                    </div>
                                </div>
                            </div>
                        }
                        <div className="panel-box-select">
                            <span className="col-md-2">Photo *</span>
                            <div className="col-md-10">
                                <OneFileUpload file={photo}
                                               setFile={setPhoto}
                                               propsClass={"border-0"}
                                />
                            </div>
                        </div>
                        {
                            existingBanner !== null && <div className="panel-box-select">
                                <span className="col-md-2">Existing Photo</span>
                                <div className="col-md-10">
                                    <div className="panel-website-icon-show">
                                        <LazyLoadImage
                                            src={existingBanner}
                                            effect="blur"
                                        />
                                    </div>
                                </div>
                            </div>
                        }
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
                                <span className="col-md-2 ">Meta Title</span>
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
