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

const AddViewNews = () => {
    const router = useRouter();
    const [isPublished, setIsPublished] = useState(false);
    const [name, setName] = useState("");
    const [shortContent, setShortContent] = useState("");
    const [content, setContent] = useState("");
    const [publishDate, setPublishDate] = useState("");
    const [clientComment, setClientComment] = useState("");
    const [category, setCategory] = useState("");
    const [newsCategory, setNewsCategory] = useState([]);

    const [existPhoto, setExistPhoto] = useState("");
    const [photo, setPhoto] = useState("");
    const [existBanner, setExistBanner] = useState("");
    const [bannerPhoto, setBannerPhoto] = useState("");

    const [metaTitle, setMetaTitle] = useState("");
    const [metaDescription, setMetaDescription] = useState("");
    const [metaKeyword, setMetaKeyword] = useState("");

    useEffect(() => {
        const getRoutuerSlider = async () => {
            var id = router.query.Id;
            if (id !== undefined) {
                try {
                    var response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/News/GetEditNews?Id=${id}`);
                    if (response.data.succeeded) {
                        const dataValues = response.data.data;
                        setName(dataValues.title);
                        setShortContent(dataValues.shortContent);
                        setContent(dataValues.content);
                        setCategory(dataValues.categoryId);
                        setClientComment(dataValues.commentShow);
                        setExistPhoto(`/${dataValues.featurePhoto}`);
                        setExistBanner(`/${dataValues.bannerPhoto}`);
                        setIsPublished(dataValues.isPublished)
                        if (dataValues.publishDate) {
                            const formattedDate = new Date(dataValues.publishDate).toISOString().split('T')[0];
                            setPublishDate(formattedDate);
                        }

                        setMetaTitle(dataValues.metaTitle);
                        setMetaDescription(dataValues.metaDescription);
                        setMetaKeyword(dataValues.metaKeyword);
                    }
                } catch (e) {
                    console.error(e);
                }
            }
        }
        getRoutuerSlider();
    }, [router.query.Id]);

    useEffect(() => {
        const getNewsCategory = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/News/GetAllNewsCategory`);
                if (response.data.succeeded) {
                    setNewsCategory(response.data.data.newsCategories);
                }
            } catch (error) {
                console.error(error);
            }
        }
        getNewsCategory();
    }, []);
    const handleSubmit = async (e) => {
        e.preventDefault();
        const formData = new FormData();
        router.query.Id !== undefined && formData.append('Id', router.query.Id);

        formData.append('Title', name);
        formData.append('ShortContent', shortContent);
        formData.append('Content', content);
        formData.append('IsPublished', isPublished);
        formData.append('PublishDate', publishDate);
        formData.append('NewsCategoryId', category);
        formData.append('CommentShow', clientComment);
        photo && formData.append('FeaturedPhoto', photo);
        bannerPhoto && formData.append('BannerPhoto', bannerPhoto);

        formData.append('MetaTitle', metaTitle);
        formData.append('MetaDescription', metaDescription);
        formData.append('MetaKeyword', metaKeyword);

        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/News/UpdateNews`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            if (response.data.succeeded) {
                toast.success('News updated successfully');
                router.push('/admin/news');
            } else {
                toast.error(`Error updating ${name} news`);
            }
        } catch (error) {
            console.error(`Error updating ${name} news`, error);
        }
    }


    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header mb-3">
                    <div className="board-header">
                        <FaArrowAltCircleRight/>
                        <h2>{router.query.Id ? "Edit Portfolio" : "Add Portfolio"}</h2>
                    </div>
                    <div
                        className="view-border-header__add-view"
                        onClick={() => router.push("/admin/portfolio")}
                    >
                        <FaPlus/>
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="panel-box-select">
                            <span className="col-md-2">News Published *</span>
                            <div className="col-md-10">
                                <input
                                    type="checkbox"
                                    value={isPublished}
                                    onChange={(e) => setIsPublished(!isPublished)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">News Title *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={name}
                                    onChange={(e) => setName(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">News Short Content *</span>
                            <div className="col-md-10">
                                <textarea
                                    rows="4"
                                    value={shortContent}
                                    onChange={(e) => setShortContent(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">News Content *</span>
                            <div className="col-md-10">
                                <WYSIWYG
                                    text={content}
                                    setText={setContent}
                                    className="w-75"
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">News Publish Date </span>
                            <div className="col-md-10">
                                <input
                                    type="date"
                                    value={publishDate}
                                    onChange={(e) => setPublishDate(e.target.value)}
                                    className="w-25"
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
                                    {
                                        router.query.Id === "" ? <option value="">Select Category</option> : ""
                                    }
                                    {
                                        newsCategory.map((category, index) => (
                                            <option key={category.id} value={category.id}>{category.title}</option>
                                        ))
                                    }
                                </select>
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Comment  *</span>
                            <div className="col-md-10">
                                <select
                                    value={clientComment}
                                    onChange={(e) => setClientComment(e.target.value)}
                                >
                                    <option value="true">On</option>
                                    <option value="false">Off</option>
                                </select>
                            </div>
                        </div>
                        <h3 className="panel-website-icon">
                            Photo and Banner
                        </h3>
                        {
                            existPhoto && (
                                <div className="panel-box-select">
                                    <span className="col-md-3 ">Existing Photo</span>
                                    <div className="col-md-9">
                                        <div className="panel-website-icon-show">
                                            <LazyLoadImage
                                                src={existPhoto}
                                            />
                                        </div>
                                    </div>
                                </div>
                            )
                        }
                        <div className="panel-box-select">
                            <span className="col-md-3 ">New Photo</span>
                            <div className="col-md-9">
                                <div className="panel-website-icon-show">
                                    <OneFileUpload file={photo}
                                                   setFile={setPhoto}/>
                                </div>
                            </div>
                        </div>
                        {
                            existPhoto && (
                                <div className="panel-box-select">
                                    <span className="col-md-3 ">Existing Banner</span>
                                    <div className="col-md-9">
                                        <div className="panel-website-icon-show">
                                            <LazyLoadImage
                                                src={existBanner}
                                            />
                                        </div>
                                    </div>
                                </div>
                            )
                        }
                        <div className="panel-box-select">
                            <span className="col-md-3 ">New Banner</span>
                            <div className="col-md-9">
                                <div className="panel-website-icon-show">
                                    <OneFileUpload file={bannerPhoto}
                                                   setFile={setBannerPhoto}/>
                                </div>
                            </div>
                        </div>

                        <div className="tab-content">
                            <h3 className="panel-website-icon">
                                SEO INFORMATION
                            </h3>
                            <div className="panel-box-select">
                                <span className="col-md-2 ">Meta Keyword</span>
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

export default AddViewNews;
