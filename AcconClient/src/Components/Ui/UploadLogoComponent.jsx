import React from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";

const UploadLogoComponent = ({logoFile,setLogoFile,title}) => {
    const handleSubmitLogo= (data) => {
        console.log(data);
    }
    return <>
        <div className="tab-content">
            <h3 className="panel-website-icon">
                {title}
            </h3>
            <div className="panel-box-select">
                <span className="col-md-3 ">Existing Photo</span>
                <div className="col-md-9">
                    <div className="panel-website-icon-show">
                        <LazyLoadImage
                            src={"/logo.png"}
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
    </>
};

export default UploadLogoComponent;
