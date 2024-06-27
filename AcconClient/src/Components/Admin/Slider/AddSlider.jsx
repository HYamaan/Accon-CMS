import React, {useState} from 'react';
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import {useRouter} from "next/router";

const AddSlider = () => {
    const router = useRouter();
    const [sliderImage,setSliderImage] = useState(null);
    const [heading, setHeading] = useState("");
    const [content, setContent] = useState("");
    const [button1Text, setButton1Text] = useState("");
    const [button1Url, setButton1Url] = useState("");
    const [button2Text, setButton2Text] = useState("");
    const [button2Url, setButton2Url] = useState("");


    const handleSubmit = () => {
        console.log(heading, metaTitle, content, metaDescription);
    }
    return <>
        <div className="content-wrapper">
            <div className="view-border-header mb-3">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>Add Slider</h2>
                </div>
                <div className="view-border-header__add-view"
                     onClick={() => router.push("/admin/slider")}
                >
                    <FaPlus/>
                    <span>View All</span>
                </div>
            </div>
            <div className="panel-box">
                <div className="panel-box-body">
                    <div className="panel-box-select">
                        <span className="col-md-2 ">Photo</span>
                        <div className="col-md-10">
                            <OneFileUpload setFile={setSliderImage} file={sliderImage}/>
                        </div>
                    </div>
                    <div className="panel-box-select">
                        <span className="col-md-2 ">Heading</span>
                        <div className="col-md-10">
                            <input
                                type="text"
                                value={heading}
                                onChange={(e) => setHeading(e.target.value)}
                            />
                        </div>
                    </div>
                    <div className="panel-box-select">
                        <span className="col-md-2 ">Content</span>
                        <div className="col-md-10">
                            <textarea
                                rows="4"
                                value={content}
                                onChange={(e) => setContent(e.target.value)}
                            />
                        </div>
                    </div>
                    <div className="panel-box-select">
                        <span className="col-md-2 ">Button 1 Text</span>
                        <div className="col-md-10">
                            <input
                                type="text"
                                value={button1Text}
                                onChange={(e) => setButton1Text(e.target.value)}
                            />
                        </div>
                    </div>
                    <div className="panel-box-select">
                        <span className="col-md-2 ">Button 1 Url</span>
                        <div className="col-md-10">
                            <input
                                type="text"
                                value={button1Url}
                                onChange={(e) => setButton1Url(e.target.value)}
                            />
                        </div>
                    </div>
                    <div className="panel-box-select">
                        <span className="col-md-2 ">Button 2 Text</span>
                        <div className="col-md-10">
                            <input
                                type="text"
                                value={button2Text}
                                onChange={(e) => setButton2Text(e.target.value)}
                            />
                        </div>
                    </div>
                    <div className="panel-box-select">
                        <span className="col-md-2 ">Button 2 Url</span>
                        <div className="col-md-10">
                            <input
                                type="text"
                                value={button2Url}
                                onChange={(e) => setButton2Url(e.target.value)}
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

export default AddSlider;
