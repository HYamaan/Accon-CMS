import React, {useState} from 'react';
import {FaArrowAltCircleRight} from "react-icons/fa";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";

const WhyChooseUsMainPhoto = () => {
    const [mainPhoto, setMainPhoto] = useState("/why-choose-item-bg.jpg");

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>Why Choose Us (Item Background)</h2>
                </div>
            </div>
            <div className="panel-box mt-3">
                <div className="panel-box-body">
                    <UploadLogoComponent
                        logoFile={mainPhoto}
                        setLogoFile={setMainPhoto}
                    />
                </div>
            </div>
        </div>
    </>
};

export default WhyChooseUsMainPhoto;
