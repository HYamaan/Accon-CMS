import React, {useState} from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";

const FavIcon = () => {
    const [logoFile, setLogoFile] = useState("/favicon.png");
    const title = "Favicon";
    return <>
    <UploadLogoComponent logoFile={logoFile} setLogoFile={setLogoFile} title={title}/>
    </>
};

export default FavIcon;
