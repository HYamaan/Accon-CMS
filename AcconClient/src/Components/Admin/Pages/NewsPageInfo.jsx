import React, {useEffect, useState} from 'react';
import axios from "axios";
import {toast} from "react-toastify";

const NewsPageInfo = () => {
    const [newsHeading, setNewsHeading] = useState("");
    const [metaTitle, setMetaTitle] = useState("");
    const [metaKeyword, setMetaKeyword] = useState("");
    const [metaDescription, setMetaDescription] = useState("");

    useEffect(() => {
        const fetchHomePageInfo = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Page/GetFaqPage`);
                if(response.data.succeeded) {
                    var data = response.data.data;
                    setNewsHeading(data.title);
                    setMetaTitle(data.metaTitle);
                    setMetaKeyword(data.metaKeywords);
                    setMetaDescription(data.metaDescription);
                }
            }catch (error) {
                toast.error('Error fetching page:', error);
                console.error('Error fetching page:', error);
            }
        }
        fetchHomePageInfo();
    },[]);
    const handleSubmit =async () => {
        try {

            const data ={
                "Heading": newsHeading,
                "metaTitle": metaTitle,
                "metaDescription": metaDescription,
                "metaKeywords": metaKeyword
            };
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Page/UpdateNewsPage`, data);
            if(response.data.succeeded) {
                toast.success('Page updated successfully');
            }else {
                toast.error('Error updating page:', response.data.message);
            }

        }catch (error) {
            toast.error('Error updating page:', error);
            console.error('Error updating page:', error);
        }
    }
    return <>
        <div className="panel-box-body">
            <div className="panel-box-select">
                <span className="col-md-2 ">News Heading</span>
                <div className="col-md-10">
                    <input
                        type="text"
                        value={newsHeading}
                        onChange={(e) => setNewsHeading(e.target.value)}
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

export default NewsPageInfo;
