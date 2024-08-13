import React, {useEffect, useState} from 'react';
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import WYSIWYG from "@/Components/WYSIWYG/WYSIWYG";
import axios from "axios";
import {toast} from "react-toastify";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";

const AboutPageInfo = () => {
    const [logoFile, setLogoFile] = useState("");
    const [existingLogo, setExistingLogo] = useState("");
    const title = "Photo Section";

    const [aboutHeading, setAboutHeading] = useState("");
    const [aboutContent, setAboutContent] = useState("");
    const [missionHeading, setMissionHeading] = useState("");
    const [missionContent, setMissionContent] = useState("");
    const [visionHeading, setVisionHeading] = useState("");
    const [visionContent, setVisionContent] = useState("");
    const [metaTitle, setMetaTitle] = useState("");
    const [metaKeyword, setMetaKeyword] = useState("");
    const [metaDescription, setMetaDescription] = useState("");


    useEffect(() => {
        const fetchHomePageInfo = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Page/GetAboutPage`);
                if (response.data.succeeded) {
                    var data = response.data.data;
                    setAboutHeading(data.title);
                    setAboutContent(data.content);
                    setMissionHeading(data.missionTitle);
                    setMissionContent(data.missionContent);
                    setVisionHeading(data.visionTitle);
                    setVisionContent(data.visionContent);
                    setMetaTitle(data.metaTitle);
                    setMetaKeyword(data.metaKeywords);
                    setMetaDescription(data.metaDescription);
                    setExistingLogo(`/${data.photo}`)
                }
            } catch (error) {
                toast.error('Error fetching page:', error);
                console.error('Error fetching page:', error);
            }
        }
        fetchHomePageInfo();
    }, []);
    const handleSubmit = async (e) => {
        try {
            e.preventDefault();
            const formData = new FormData();
            logoFile && formData.append('Photo', logoFile);
            formData.append('AboutHeader', aboutHeading);
            formData.append('AboutContent', aboutContent);
            formData.append('MissionHeader', missionHeading);
            formData.append('MissionContent', missionContent);
            formData.append('VisionHeader', visionHeading);
            formData.append('VisionContent', visionContent);
            formData.append('MetaTitle', metaTitle);
            formData.append('MetaKeywords', metaKeyword);
            formData.append('MetaDescription', metaDescription);
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Page/UpdateAboutPage`, formData);
            if (response.data.succeeded) {
                toast.success('Page updated successfully');
            } else {
                toast.error('Error updating page:', response.data.message);
            }

        } catch (error) {
            toast.error('Error updating page:', error);
            console.error('Error updating page:', error);
        }
    }


    return <>
        <div className="tab-content">
            {
                <h3 className="panel-website-icon">
                    {title}
                </h3>
            }
            <div className="panel-box-select">
                <span className="col-md-3 ">Existing Photo</span>
                <div className="col-md-9">
                    <div className="panel-website-icon-show">
                        <LazyLoadImage
                            effect="blur"
                            src={existingLogo}
                        />
                    </div>
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-3 ">New Photo</span>
                <div className="col-md-9">
                    <div className="panel-website-icon-show">
                        <OneFileUpload file={logoFile}
                                       setFile={setLogoFile}/>
                    </div>
                </div>
            </div>
        </div>
        <div className="tab-content">
            <h3 className="panel-website-icon">
                Other Information Section
            </h3>
            <div className="panel-box-body">
                <div className="panel-box-select">
                    <span className="col-md-2 ">About Heading</span>
                    <div className="col-md-10">
                        <input
                            type="text"
                            value={aboutHeading}
                            onChange={(e) => setAboutHeading(e.target.value)}
                        />
                    </div>
                </div>
                <div className="panel-box-select">
                    <span className="col-md-2 ">About Content</span>
                    <div className="col-md-10">
                        <WYSIWYG
                            text={aboutContent}
                            setText={setAboutContent}
                            className="w-75"
                        />
                    </div>
                </div>
                <div className="panel-box-select">
                    <span className="col-md-2 ">Mission Heading</span>
                    <div className="col-md-10">
                        <input
                            type="text"
                            value={missionHeading}
                            onChange={(e) => setMissionHeading(e.target.value)}
                        />
                    </div>
                </div>
                <div className="panel-box-select">
                    <span className="col-md-2 ">Mission Content</span>
                    <div className="col-md-10">
                        <input
                            type="text"
                            value={missionContent}
                            onChange={(e) => setMissionContent(e.target.value)}
                        />
                    </div>
                </div>
                <div className="panel-box-select">
                    <span className="col-md-2 ">Vision Heading</span>
                    <div className="col-md-10">
                        <input
                            type="text"
                            value={visionHeading}
                            onChange={(e) => setVisionHeading(e.target.value)}
                        />
                    </div>
                </div>
                <div className="panel-box-select">
                    <span className="col-md-2 ">Vision Content</span>
                    <div className="col-md-10">
                        <input
                            type="text"
                            value={visionContent}
                            onChange={(e) => setVisionContent(e.target.value)}
                        />
                    </div>
                </div>
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
                        <input
                            type="text"
                            value={metaKeyword}
                            onChange={(e) => setMetaKeyword(e.target.value)}
                        />
                    </div>
                </div>
                <div className="panel-box-select">
                    <span className="col-md-2 ">Meta Description</span>
                    <div className="col-md-10">
                        <input
                            type="text"
                            value={metaDescription}
                            onChange={(e) => setMetaDescription(e.target.value)}
                        />
                    </div>
                </div>
                <div className="panel-box-select ps-md-3">
                    <div className="col-md-2"></div>
                    <div className="col-md-10">
                        <button onClick={handleSubmit}
                                className="secondary-button panel-website-icon-show__button">Update Information
                        </button>
                    </div>
                </div>
            </div>

        </div>
    </>
};

export default AboutPageInfo;
