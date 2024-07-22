import React, {useEffect, useState} from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import axios from "axios";
import {toast} from "react-toastify";

const LoginBackground = () => {
    const [logoFile, setLogoFile] = useState(null);
    const [existLogoFile, setExistLogoFile] = useState(null);

    useEffect(() => {
        const getLogos = async () => {
            var response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Settings/GetLoginBackgroundSettings`);
            if(response.data.succeeded){
                setExistLogoFile(`/${response.data.data.photo}`);
            }
        }
        getLogos();
    }, []);

    const handleSubmitLogo= async () => {
        const formData = new FormData();
        formData.append('Photo', logoFile);
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateBackgroundLogo`,formData)
        if(result.data.succeeded) {
            toast.success("Settings saved successfully");
            setExistLogoFile(`/${result.data.data.photo}`)
        }else{
            toast.error("An error occurred while saving the settings");
        }
    }


    return <>
        <div className="tab-content">
            <h3 className="panel-website-icon">
                Website Logo
            </h3>
            {
                existLogoFile != null && (
                    <div className="panel-box-select">
                        <span className="col-md-3 ">Existing Photo</span>
                        <div className="col-md-9">
                            <div className="panel-website-background-icon-show">
                                <LazyLoadImage
                                    src={existLogoFile}
                                />
                            </div>
                        </div>
                    </div>
                )
            }
            <div className="panel-box-select">
                <span className="col-md-3 ">New Photo</span>
                <div className="col-md-9">
                    <div className="panel-website-background-icon-show">
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
    </>
};

export default LoginBackground;
