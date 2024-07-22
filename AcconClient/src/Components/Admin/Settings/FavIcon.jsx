import React, {useEffect, useState} from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import axios from "axios";
import {toast} from "react-toastify";

const FavIcon = () => {
    const [logoFile, setLogoFile] = useState("/favicon.png");
    const [existLogoFile, setExistLogoFile] = useState(null);
    const title = "Favicon";

    useEffect(() => {
        const getLogos = async () => {
            var response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Settings/GetFaviconSettings`);
            if(response.data.succeeded){
                setExistLogoFile(`/${response.data.data.favicon}`);
            }
        }
        getLogos();
    }, []);

    const handleSubmitLogo= async () => {
        const formData = new FormData();
        formData.append('Photo', logoFile);
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateFavicon`,formData)
        if(result.data.succeeded) {
            toast.success("Settings saved successfully");
            setExistLogoFile(`/${result.data.data.photo}`)
        }else{
            toast.error("An error occurred while saving the settings");
        }
    }

    return <>
    <UploadLogoComponent
        logoFile={logoFile}
        setLogoFile={setLogoFile}
        title={title}
        handleSubmitLogo={handleSubmitLogo}
        existPhoto={existLogoFile}
    />
    </>
};

export default FavIcon;
