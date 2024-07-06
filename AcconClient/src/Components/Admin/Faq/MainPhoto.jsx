import React, {useEffect, useState} from 'react';
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import axios from "axios";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";
import {toast} from "react-toastify";

const MainPhoto = () => {
    const [mainPhoto, setMainPhoto] = useState("/faq-main-photo.png");
    const [existedMainPhoto, setExistedMainPhoto] = useState("");
    const [loading, setLoading] = useState(true);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Faq/GetFaqMainPhoto`);
                if (response.data.succeeded) {
                    console.log("response", response.data.data)
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
        formData.append('Photo', mainPhoto);
        console.log("mainPhoto",mainPhoto)
        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Faq/UpdateFaqMainPhoto`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            if (response.data.succeeded) {
                toast.success('Main Photo updated successfully');

                setExistedMainPhoto(`/${response.data.data.photo}`)
            } else {
                toast.error(`Error updating main photo`);
            }
        } catch (error) {
            console.error(`Error updating main photo`, error);
        }
    }
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
                        handleSubmitLogo={handleSubmitLogo}
                        existPhoto={existedMainPhoto}
                    />
                </div>
            </div>
        </div>
    </>
};

export default MainPhoto;
