import React, { useState, useEffect } from 'react';
import { useRouter } from 'next/router';
import { FaArrowAltCircleRight } from 'react-icons/fa';
import Logo from "@/Components/Admin/Settings/Logo";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import { LazyLoadImage } from "react-lazy-load-image-component";
import FavIcon from "@/Components/Admin/Settings/FavIcon";
import LoginBackground from "@/Components/Admin/Settings/LoginBackground";
import GeneralContent from "@/Components/Admin/Settings/GeneralContent";
import EmailSettings from "@/Components/Admin/Settings/EmailSettings";
import SideBarAndFooter from "@/Components/Admin/Settings/SideBarAndFooter";
import HomePage from "@/Components/Admin/Settings/HomePage";

const Settings = ({ slug, combinedSlug }) => {
    const router = useRouter();
    const [activeTab, setActiveTab] = useState(slug[1] || "");

    useEffect(() => {
        setActiveTab(slug[1] || "");
    }, [slug]);

    const handleClickRouter = (path) => {
        setActiveTab(path);
        router.push(`/admin/settings/${path}`);
    };

    return (
        <>
            <div className="content-wrapper">
                <div className="board-header">
                    <FaArrowAltCircleRight />
                    <h2>Settings</h2>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="nav-settings">
                            <div
                                onClick={() => handleClickRouter("")}
                                className={`nav-settings__item ${activeTab === "" ? "active" : ""}`}
                            >
                                Logo
                            </div>
                            <div
                                onClick={() => handleClickRouter("favicon")}
                                className={`nav-settings__item ${activeTab === "favicon" ? "active" : ""}`}
                            >
                                Favicon
                            </div>
                            <div
                                onClick={() => handleClickRouter("login-background")}
                                className={`nav-settings__item ${activeTab === "login-background" ? "active" : ""}`}
                            >
                                Login Background
                            </div>
                            <div
                                onClick={() => handleClickRouter("general-content")}
                                className={`nav-settings__item ${activeTab === "general-content" ? "active" : ""}`}
                            >
                                General Content
                            </div>
                            <div
                                onClick={() => handleClickRouter("email-settings")}
                                className={`nav-settings__item ${activeTab === "email-settings" ? "active" : ""}`}
                            >
                                Email Settings
                            </div>
                            <div
                                onClick={() => handleClickRouter("sidebar-footer")}
                                className={`nav-settings__item ${activeTab === "sidebar-footer" ? "active" : ""}`}
                            >
                                Sidebar & Footer
                            </div>
                            <div
                                onClick={() => handleClickRouter("home-page")}
                                className={`nav-settings__item ${activeTab === "home-page" ? "active" : ""}`}
                            >
                                Home Page
                            </div>
                        </div>
                        {slug[0] === "settings" && !slug[1] && <Logo />}
                        {slug[1] === "favicon" && <FavIcon />}
                        {slug[1] === "login-background" && <LoginBackground />}
                        {slug[1] === "general-content" && <GeneralContent />}
                        {slug[1] === "email-settings" && <EmailSettings />}
                        {slug[1] === "sidebar-footer" && <SideBarAndFooter />}
                        {slug[1] === "home-page" && <HomePage />}
                    </div>
                </div>
            </div>
        </>
    );
};

export default Settings;
