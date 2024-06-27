import React, {useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import WYSIWYG from "@/Components/WYSIWYG/WYSIWYG";

const AddFaq = () => {
    const router = useRouter();
    const [faqTitle, setFaqTitle] = useState("");
    const [faqContent, setFaqContent] = useState("");

    const handleSubmit = () => {
        console.log(heading, metaTitle, content, metaDescription);
    }
    return <>
        <div className="content-wrapper">
            <div className="view-border-header mb-3">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>Add Faq</h2>
                </div>
                <div className="view-border-header__add-view"
                     onClick={() => router.push("/admin/faq")}
                >
                    <FaPlus/>
                    <span>View All</span>
                </div>
            </div>
            <div className="panel-box">
                <div className="panel-box-body">
                    <div className="panel-box-select">
                        <span className="col-md-2 ">FAQ Title *</span>
                        <div className="col-md-10">
                            <input
                                type="text"
                                value={faqTitle}
                                onChange={(e) => setFaqTitle(e.target.value)}
                            />
                        </div>
                    </div>
                    <div className="panel-box-select">
                        <span className="col-md-2 ">FAQ Content *</span>
                        <div className="col-md-10">
                           <WYSIWYG
                            text={faqContent}
                            setText={setFaqContent}
                            className="w-75"
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
            </div>
        </div>
    </>
};

export default AddFaq;
