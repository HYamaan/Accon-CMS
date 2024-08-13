import React, {useEffect, useState} from 'react';
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import axios from "axios";
import {toast} from "react-toastify";

const GeneralContent = () => {
    const [footerCopyRight, setFooterCopyRight] = useState("");
    const [footerAddress, setFooterAddress] = useState("");
    const [footerPhone, setFooterPhone] = useState("");
    const [footerWorkingHour, setFooterWorkingHour] = useState("");
    const [footerAboutUs, setFooterAboutUs] = useState("");
    const [topBarEmail, setTopBarEmail] = useState("");
    const [topBarPhoneNumber, setTopBarPhoneNumber] = useState("");
    const [contactMapIFrame, setContactMapIFrame] = useState("");

    const [footerAddressIcon, setFooterAddressIcon] = useState(null);
    const [existFooterAddressIcon, setExistFooterAddressIcon] = useState(null);
    const [footerPhoneIcon, setFooterPhoneIcon] = useState(null);
    const [existFooterPhoneIcon, setExistFooterPhoneIcon] = useState(null);
    const [footerWorkingHourIcon, setFooterWorkingHourIcon] = useState(null);
    const [existFooterWorkingHourIcon, setExistFooterWorkingHourIcon] = useState(null);
    const footerAddressIconTitle = "Footer Address Icon";
    const footerPhoneIconTitle = "Footer Phone Icon";
    const footerWorkingHourIconTitle = "Footer Working Hour Icon";


    useEffect(() => {
        const getGeneralContent = async () => {
            const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Settings/GetGeneralContentSettings`);
            if (response.data.succeeded) {
                var getData = response.data.data;
                setFooterCopyRight(getData.copyRight);
                setFooterAddress(getData.address);
                setFooterPhone(getData.phone);
                setFooterWorkingHour(getData.workingHour);
                setFooterAboutUs(getData.aboutUs);
                setTopBarEmail(getData.topBarEmail);
                setTopBarPhoneNumber(getData.topBarPhone);
                setContactMapIFrame(getData.contactMap);
                setExistFooterAddressIcon(`/${getData.footerAdressIcon}`);
                setExistFooterPhoneIcon(`/${getData.footerPhoneIcon}`);
                setExistFooterWorkingHourIcon(`/${getData.footerWorkingHoutIcon}`);
            }
        }
        getGeneralContent();
    }, []);

    const handleSubmit = async () => {
        const data = {
            footerCopyRight: footerCopyRight,
            footerAdress: footerAddress,
            footerPhone: footerPhone,
            footerWorkingHours: footerWorkingHour,
            footerAboutUs: footerAboutUs,
            topBarEmail: topBarEmail,
            topBarPhone: topBarPhoneNumber,
            contactMap: contactMapIFrame
        };
        const  result =await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateGeneralContent`, data);
        console.log("result",result.data)
        if (result.data.succeeded) {
            toast.success("Settings saved successfully");
        } else {
            toast.error("An error occurred while saving the settings");
        }

    };

    const handleSubmitAdressIcon = async () => {
        var formData = new FormData();
        if(footerAddressIcon === null){
            toast.error("Please select a file");
            return;
        }
        formData.append('Photo', footerAddressIcon);
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateAdressIcon`, formData);
        if (result.data.succeeded) {
            toast.success("Settings saved successfully");
            setExistFooterAddressIcon(`/${result.data.data.photo}`);
        } else {
            toast.error("An error occurred while saving the settings");
        }
    }

    const handleSubmitPhoneIcon = async () => {
        var formData = new FormData();
        if(footerPhoneIcon === null){
            toast.error("Please select a file");
            return;
        }
        formData.append('Photo', footerPhoneIcon);
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdatePhoneIcon`, formData);
        if (result.data.succeeded) {
            toast.success("Settings saved successfully");
            setExistFooterPhoneIcon(`/${result.data.data.photo}`);
        } else {
            toast.error("An error occurred while saving the settings");
        }
    }
    const handleSubmitWorkingHourIcon = async () => {
        if(footerWorkingHourIcon === null){
            toast.error("Please select a file");
            return;
        }
        var formData = new FormData();
        formData.append('Photo', footerWorkingHourIcon);
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateWorkingHourIcon`, formData);
        if (result.data.succeeded) {
            toast.success("Settings saved successfully");
            setExistFooterWorkingHourIcon(`/${result.data.data.photo}`);
        } else {
            toast.error("An error occurred while saving the settings");
        }
    }


    return (
        <div className="content-wrapper bg-white">
            <div className="text-danger mb-4 mt-2 ms-2">
                If you do not want to show a social media in your front end page, just leave the input field blank.
            </div>

            <div className="panel-box-select">
                <span className="col-md-4 ">Footer - Copyright</span>
                <div className="col-md-8">
                    <input
                        type="text"
                        value={footerCopyRight}
                        onChange={(e) => setFooterCopyRight(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4 ">Footer - Address</span>
                <div className="col-md-8">
                    <textarea
                        rows="3"
                        value={footerAddress}
                        onChange={(e) => setFooterAddress(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4 ">Footer - Phone</span>
                <div className="col-md-8">
                    <textarea
                        rows="3"
                        value={footerPhone}
                        onChange={(e) => setFooterPhone(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4 ">Footer - Working Hour</span>
                <div className="col-md-8">
                    <textarea
                        value={footerWorkingHour}
                        rows="3"
                        onChange={(e) => setFooterWorkingHour(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4 ">Footer - About Us</span>
                <div className="col-md-8">
                    <textarea
                        rows="5"
                        value={footerAboutUs}
                        onChange={(e) => setFooterAboutUs(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4 ">Top Bar Email</span>
                <div className="col-md-8">
                    <input
                        type="text"
                        value={topBarEmail}
                        onChange={(e) => setTopBarEmail(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4 ">Top Bar Phone Number</span>
                <div className="col-md-8">
                    <input
                        type="text"
                        value={topBarPhoneNumber}
                        onChange={(e) => setTopBarPhoneNumber(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4 ">Contact Map iFrame</span>
                <div className="col-md-8">
                    <textarea
                        rows="7"
                        value={contactMapIFrame}
                        onChange={(e) => setContactMapIFrame(e.target.value)}
                    />
                </div>
            </div>


            <div className="panel-box-select ps-md-3">
                <div className="col-md-4"></div>
                <div className="col-md-8">
                    <button onClick={handleSubmit} className="secondary-button">Submit</button>
                </div>
            </div>

            <UploadLogoComponent logoFile={footerAddressIcon}
                                 setLogoFile={setFooterAddressIcon}
                                 title={footerAddressIconTitle}
                                 existPhoto={existFooterAddressIcon}
                                 handleSubmitLogo={handleSubmitAdressIcon}
            />
            <UploadLogoComponent logoFile={footerPhoneIcon}
                                 setLogoFile={setFooterPhoneIcon}
                                 title={footerPhoneIconTitle}
                                 existPhoto={existFooterPhoneIcon}
                                 handleSubmitLogo={handleSubmitPhoneIcon}
            />
            <UploadLogoComponent logoFile={footerWorkingHourIcon}
                                 setLogoFile={setFooterWorkingHourIcon}
                                 title={footerWorkingHourIconTitle}
                                 existPhoto={existFooterWorkingHourIcon}
                                 handleSubmitLogo={handleSubmitWorkingHourIcon}
            />

        </div>
    );
};


export default GeneralContent;
