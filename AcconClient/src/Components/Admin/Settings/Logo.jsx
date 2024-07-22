import React, {useEffect, useState} from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import {toast} from "react-toastify";
import axios from "axios";

const Logo = () => {
    const [logoFile, setLogoFile] = useState(null);
    const [existLogoFile, setExistLogoFile] = useState(null);
    const [adminLogoFile, setAdminLogoFile] = useState(null);
    const [existAdminLogoFile, setExistAdminLogoFile] = useState(null);

    useEffect(() => {
        const getLogos = async () => {
            var response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Settings/GetLogoSettings`);
            console.log("respose",response.data);
            if(response.data.succeeded){

                setExistLogoFile(`/${response.data.data.websiteLogo}`);
                setExistAdminLogoFile(`/${response.data.data.adminLogo}`);
            }
        }
        getLogos();
    }, []);


    const handleSubmitLogo= async () => {
        const formData = new FormData();
        formData.append('Photo', logoFile);
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateWebsiteLogo`,formData)
        if(result.data.succeeded) {
            toast.success("Settings saved successfully");
            setExistLogoFile(`/${result.data.data.photo}`)
        }else{
            toast.error("An error occurred while saving the settings");
        }
    }
    const handleSubmitAdminLogo= async () => {
        const formData = new FormData();
        formData.append('Photo', adminLogoFile);
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateAdminLogo`,formData)
        if(result.data.succeeded) {
            toast.success("Settings saved successfully");
            setExistAdminLogoFile(`/${result.data.data.photo}`)
        }else{
            toast.error("An error occurred while saving the settings");
        }
    }
    return <>
        <div className="tab-content">
            <h3 className="panel-website-icon">
                Website Logo
            </h3>
            <div className="panel-box-select">
                <span className="col-md-3 ">Existing Photo</span>
                <div className="col-md-9">
                    <div className="panel-website-icon-show">
                        <LazyLoadImage
                            src={existLogoFile}
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
            <div className="panel-box-select ps-md-3 ">
                <div className="col-md-3"></div>
                <div className="col-md-9">
                    <button onClick={handleSubmitLogo}
                            className="secondary-button panel-website-icon-show__button">Submit
                    </button>
                </div>
            </div>
        </div>
        <div className="tab-content">
            <h3 className="panel-website-icon">
                Admin Logo
            </h3>
            <div className="panel-box-select">
                <span className="col-md-3 ">Existing Photo</span>
                <div className="col-md-9">
                    <div className="panel-website-icon-show">
                        <LazyLoadImage
                            src={existAdminLogoFile}
                        />
                    </div>
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-3 ">New Photo</span>
                <div className="col-md-9">
                    <div className="panel-website-icon-show">
                        <OneFileUpload file={adminLogoFile}
                                       setFile={setAdminLogoFile}/>
                    </div>
                </div>
            </div>
            <div className="panel-box-select ps-md-3 ">
                <div className="col-md-3"></div>
                <div className="col-md-9">
                    <button onClick={handleSubmitAdminLogo}
                            className="secondary-button panel-website-icon-show__button">Submit
                    </button>
                </div>
            </div>


        </div>
    </>
};

export default Logo;
