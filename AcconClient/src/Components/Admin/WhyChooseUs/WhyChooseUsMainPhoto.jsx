import React, {useEffect, useState} from 'react';
import {FaArrowAltCircleRight} from "react-icons/fa";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import axios from "axios";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";
import {toast} from "react-toastify";

const WhyChooseUsMainPhoto = () => {
    const [mainPhoto, setMainPhoto] = useState("/why-choose-main-photo.jpg");
    const [existedMainPhoto, setExistedMainPhoto] = useState("");
    const [loading, setLoading] = useState(true);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/WhyChooseUs/GetMainImage`);
                if (response.data.succeeded) {
                    setExistedMainPhoto(`/${response.data.data.photo}`);
                }
            } catch (error) {
                console.error('Error fetching faqs:', error);
            } finally {
                setLoading(false);
            }
        };
        fetchSliders();
    }, []);
    const handleSubmitLogo= async (e) => {
        e.preventDefault();
        const formData = new FormData();
        mainPhoto && formData.append('Photo', mainPhoto);
        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/WhyChooseUs/UpdateMainPhoto`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            if (response.data.succeeded) {
                setExistedMainPhoto(`/${response.data.data.photo}`);
                toast.success('Main Photo updated successfully');
            } else {
                toast.error(`Error updating main photo`);
            }
        } catch (error) {
            taoast.error(`Error updating main photo`);
            console.error(`Error updating main photo`, error);
        }
    }

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>Why Choose Us (Main Photo)</h2>
                </div>
            </div>
            <div className="panel-box mt-3">
                <div className="panel-box-body">
                    <UploadLogoComponent
                        logoFile={mainPhoto}
                        setLogoFile={setMainPhoto}
                        handleSubmitLogo={handleSubmitLogo}
                        existPhoto={existedMainPhoto}
                    />
                </div>
            </div>
        </div>
    </>
};

export default WhyChooseUsMainPhoto;
