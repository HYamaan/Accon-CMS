import React, {useEffect, useState} from 'react';
import { FaArrowAltCircleRight } from "react-icons/fa";
import {generateGUID} from "@/lib/generateGUID";
import axios from "axios";
import {toast} from "react-toastify";

const SideBarAndFooter = () => {

    const [recentPost,setRecentPost] = useState(0);
    const [popularPost,setPopularPost] = useState(0);

    useEffect(() => {
        const getSideBarAndFooter = async () => {
            const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Settings/GetSideFooterSettings`);
            if(response.data.succeeded){
                setRecentPost(response.data.data.recentPostCount);
                setPopularPost(response.data.data.popularPostCount);
            }
        }
        getSideBarAndFooter();
    }, []);


    const handleSubmit = async () => {
       const data = {
           PopularPostCount: popularPost,
           RecentPostCount: recentPost
            };

         const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateFooterSideBar`,data)

        if(result.data.succeeded){
            toast.success("Settings saved successfully");
        }else{
            toast.error("An error occurred while saving the settings");
        }
    };

    return (
        <div className="content-wrapper bg-white">
            <div className="panel-box-select">
                <span className="col-md-4">How many recent posts?</span>
                <div className="col-md-8">
                    <input
                        type="input"
                        value={recentPost}
                        onChange={(e) => setRecentPost(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4">How many popular posts?</span>
                <div className="col-md-8">
                    <input
                        type="input"
                        value={popularPost}
                        onChange={(e) => setPopularPost(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select ps-md-3">
                <div className="col-md-4"></div>
                <div className="col-md-8">
                    <button onClick={handleSubmit} className="secondary-button">Submit</button>
                </div>
            </div>
        </div>
    );
};


export default SideBarAndFooter;
