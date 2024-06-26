import React, {useState} from 'react';
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import WYSIWYG from "@/Components/WYSIWYG/WYSIWYG";

const AboutPageInfo = () => {
    const [logoFile, setLogoFile] = useState("/about_photo.jpg");
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


    const handleSubmit = () => {
        console.log('submit');
    }
    return <>
        <UploadLogoComponent logoFile={logoFile} setLogoFile={setLogoFile} title={title}/>
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
                            onChange={(e) => setMissionHeading(e.target.value)}
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
                        <button onClick={handleSubmit} className="secondary-button panel-website-icon-show__button">Update Information</button>
                    </div>
                </div>
            </div>

        </div>
    </>
};

export default AboutPageInfo;
