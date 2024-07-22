import React, {useEffect, useState} from 'react';
import { FaArrowAltCircleRight } from "react-icons/fa";
import {generateGUID} from "@/lib/generateGUID";
import axios from "axios";
import {toast} from "react-toastify";

const EmailSettings = () => {


    const [sendEmailFrom, setSendEmailFrom] = useState("");
    const [receiveEmailTo, setReceiveEmailTo] = useState("");
    const [smtpHost, setSmtpHost] = useState("");
    const [smtpPort, setSmtpPort] = useState("");
    const [smtpUsername, setSmtpUsername] = useState("");
    const [smtpPassword, setSmtpPassword] = useState("");

    useEffect(() => {
        const getEmailSettings = async () => {
            const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Settings/GetEmailSettings`);
            if(response.data.succeeded){
                var getData = response.data.data;
                setSendEmailFrom(getData.emailFrom ?? "");
                setReceiveEmailTo(getData.emailTo ?? "");
                setSmtpHost(getData.smptHost ?? "");
                setSmtpPort(getData.smptPort ?? "");
                setSmtpUsername(getData.smptUser ?? "");
                setSmtpPassword(getData.smptPassword ?? "");
            }
        }
        getEmailSettings();
    }, []);


    const handleSubmit = async () => {
        const data={
            fromEmail: sendEmailFrom,
            toEmail: receiveEmailTo,
            smtpHost: smtpHost,
            smtpPort: smtpPort,
            smtpUser: smtpUsername,
            smtpPassword: smtpPassword
        };
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateEmailSettings`,data);
        if(result.data.succeeded){
            toast.success("Settings saved successfully");
        }
        else{
            toast.error("An error occurred while saving the settings");
        }
    };

    return (
        <div className="content-wrapper bg-white">

            <div className="panel-box-select">
                <span className="col-md-4">Send Email From</span>
                <div className="col-md-8">
                    <input
                        type="text"
                        value={sendEmailFrom}
                        onChange={(e) => setSendEmailFrom(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4">Receive Email To</span>
                <div className="col-md-8">
                    <input
                        type="text"
                        value={receiveEmailTo}
                        onChange={(e) => setReceiveEmailTo(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4">SMTP Host</span>
                <div className="col-md-8">
                    <input
                        type="text"
                        value={smtpHost}
                        onChange={(e) => setSmtpHost(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4">SMTP Port</span>
                <div className="col-md-8">
                    <input
                        type="text"
                        value={smtpPort}
                        onChange={(e) => setSmtpPort(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4">SMTP Username</span>
                <div className="col-md-8">
                    <input
                        type="text"
                        value={smtpUsername}
                        onChange={(e) => setSmtpUsername(e.target.value)}
                    />
                </div>
            </div>
            <div className="panel-box-select">
                <span className="col-md-4">SMTP Password</span>
                <div className="col-md-8">
                    <input
                        type="text"
                        value={smtpPassword}
                        onChange={(e) => setSmtpPassword(e.target.value)}
                    />
                </div>
            </div>

            <div className="panel-box-select ps-md-3">
                <div className="col-md-4"></div>
                <div className="col-md-8">
                    <button onClick={handleSubmit} className="secondary-button">Submit</button>
                </div>
            </div>

        </div>
    );
};


export default EmailSettings;
