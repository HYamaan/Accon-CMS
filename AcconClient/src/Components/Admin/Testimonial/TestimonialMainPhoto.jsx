import React, {useEffect, useState} from 'react';
import {FaArrowAltCircleRight} from "react-icons/fa";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import axios from "axios";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";
import {toast} from "react-toastify";

const TestimonialMainPhoto = () => {
    const [mainPhoto, setMainPhoto] = useState("");
    const [existedMainPhoto, setExistedMainPhoto] = useState("");
    const [loading, setLoading] = useState(true);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Testimonial/GetTestimonialMainPhoto`);
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
        formData.append('Photo', mainPhoto);
        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Testimonial/TestimonialMainPhoto`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            if (response.data.succeeded) {
                toast.success('Photo updated successfully');

                setExistedMainPhoto(`/${response.data.data.photo}`)
            } else {
                toast.error(`Error updating main photo`);
            }
        } catch (error) {
            console.error(`Error updating photo`, error);
        }
    }
    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>Testimonial Main Photo</h2>
                </div>
            </div>
            <div className="panel-box mt-3">
                <div className="panel-box-body">
                    <UploadLogoComponent
                        logoFile={mainPhoto}
                        setLogoFile={setMainPhoto}
                        existPhoto={existedMainPhoto}
                        handleSubmitLogo={handleSubmitLogo}
                    />
                </div>
            </div>
        </div>
    </>
};

export default TestimonialMainPhoto;
