import React, {useState} from 'react';
import WYSIWYG from "@/Components/WYSIWYG/WYSIWYG";

const TermsPageInfo = () => {
    const [termsHeading, setTermsHeading] = useState("");
    const [termsContent, setTermsContent] = useState("");
    const [metaTitle, setMetaTitle] = useState("");
    const [metaKeyword, setMetaKeyword] = useState("");
    const [metaDescription, setMetaDescription] = useState("");

    const handleSubmit = () => {
        console.log(termsHeading,termsContent, metaTitle, metaKeyword, metaDescription);
    }
    return <>
        <div className="panel-box-body">
            <div className="panel-box-select">
                <span className="col-md-2 ">Term & Condition Heading</span>
                <div className="col-md-10">
                    <input
                        type="text"
                        value={termsHeading}
                        onChange={(e) => setTermsHeading(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-2 ">Term & Condition Content</span>
                <div className="col-md-10">
                 <WYSIWYG text={termsContent} setText={setTermsContent} className="w-75"/>
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

export default TermsPageInfo;
