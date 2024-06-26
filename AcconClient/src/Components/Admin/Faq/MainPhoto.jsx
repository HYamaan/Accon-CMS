import React, {useState} from 'react';
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";

const MainPhoto = () => {
    const [mainPhoto, setMainPhoto] = useState("/faq-main-photo.png");

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>Edit FAQ Photo</h2>
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

export default MainPhoto;
