import React, {useState} from 'react';
import WYSIWYG from "@/Components/WYSIWYG/WYSIWYG";

const PrivacyPageInfo = () => {
    const [privacyHeading, setPrivacyHeading] = useState("");
    const [privacyContent, setPrivacyContent] = useState("");
    const [metaTitle, setMetaTitle] = useState("");
    const [metaKeyword, setMetaKeyword] = useState("");
    const [metaDescription, setMetaDescription] = useState("");

    const handleSubmit = () => {
        console.log(privacyHeading,privacyContent, metaTitle, metaKeyword, metaDescription);
    }
    return <>
        <div className="panel-box-body">
            <div className="panel-box-select">
                <span className="col-md-2 ">Privacy Policy Heading</span>
                <div className="col-md-10">
                    <input
                        type="text"
                        value={privacyHeading}
                        onChange={(e) => setPrivacyHeading(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-2 ">Privacy Policy Content</span>
                <div className="col-md-10">
                    <WYSIWYG text={privacyContent} setText={setPrivacyContent} className="w-75"/>
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
            <div className="panel-box-select ps-md-3">
                <div className="col-md-2"></div>
                <div className="col-md-10">
                    <button onClick={handleSubmit}
                            className="secondary-button panel-website-icon-show__button">Update
                    </button>
                </div>
            </div>
        </div>
    </>
};

export default PrivacyPageInfo;
