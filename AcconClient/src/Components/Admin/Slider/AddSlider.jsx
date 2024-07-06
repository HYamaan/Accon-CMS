import React, {useEffect, useState} from 'react';
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import {useRouter} from "next/router";
import axios from "axios";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {toast} from "react-toastify";

const AddSlider = () => {
    const router = useRouter();
    const [sliderImage,setSliderImage] = useState(null);
    const [heading, setHeading] = useState("");
    const [content, setContent] = useState("");
    const [button1Text, setButton1Text] = useState("");
    const [button1Url, setButton1Url] = useState("");
    const [button2Text, setButton2Text] = useState("");
    const [button2Url, setButton2Url] = useState("");
    const [existingPhoto, setExistingPhoto] = useState(null);

    useEffect(() => {
        const getRoutuerSlider = async () => {
            var id = router.query.Id;
            if(id !== undefined){
                try {
                    var response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Slider/GetSliderEdit?Id=${router.query.Id}`);
                    console.log("response",response.data.data)
                    if(response.data.succeeded){
                        setExistingPhoto(`/${response.data.data.photo}`);
                        setHeading(response.data.data.heading);
                        setContent(response.data.data.content);
                        setButton1Text(response.data.data.button1Text);
                        setButton1Url(response.data.data.button1Link);
                        setButton2Text(response.data.data.button2Text);
                        setButton2Url(response.data.data.button2Link);
                    }
                }catch (e) {
                    console.error(e);
                }
            }
        }
        getRoutuerSlider();
    }, [router.query.Id]);
    console.log("sliderImage",sliderImage   )
    const handleSubmit =  async (e) => {
        e.preventDefault();
        const formData = new FormData();
       router.query.Id !== undefined && formData.append('Id', router.query.Id);
        formData.append('photo', sliderImage);
        formData.append('heading', heading);
        formData.append('content', content);
        formData.append('button1Text', button1Text);
        formData.append('button1Link', button1Url);
        formData.append('button2Text', button2Text);
        formData.append('button2Link', button2Url);
        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Slider/UpdateSlider`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            if (response.data.succeeded) {
                toast.success('Slider updated successfully');
                router.push('/admin/slider');
            } else {
                toast.error('Error updating slider');
            }
        } catch (error) {
            console.error('Error updating slider:', error);
        }
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
                    {
                        existingPhoto !== null &&  <div className="panel-box-select">
                            <span className="col-md-2">Existing Photo</span>
                            <div className="col-md-10">
                                <div className="panel-website-icon-show">
                                    <LazyLoadImage src={existingPhoto}/>
                                </div>
                            </div>
                        </div>
                    }
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
