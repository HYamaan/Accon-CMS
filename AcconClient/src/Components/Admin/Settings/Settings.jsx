import React, {useState} from 'react';
import Logo from "@/Components/Admin/Settings/Logo";
import {FaArrowAltCircleRight} from "react-icons/fa";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import {LazyLoadImage} from "react-lazy-load-image-component";
import FavIcon from "@/Components/Admin/Settings/FavIcon";
import LoginBackground from "@/Components/Admin/Settings/LoginBackground";
import GeneralContent from "@/Components/Admin/Settings/GeneralContent";
import EmailSettings from "@/Components/Admin/Settings/EmailSettings";
import SideBarAndFooter from "@/Components/Admin/Settings/SideBarAndFooter";
import HomePage from "@/Components/Admin/Settings/HomePage";

const Settings = () => {



    return <>
        <div className="content-wrapper">
            <div className="board-header">
                <FaArrowAltCircleRight/>
                <h2>Settings</h2>
            </div>
            <div className="panel-box">
                <div className="panel-box-body">
                    <div className="nav-settings">
                        <div className="nav-settings__item active">Logo</div>
                        <div className="nav-settings__item">Favicon</div>
                        <div className="nav-settings__item">Login Background</div>
                        <div className="nav-settings__item">General Content</div>
                        <div className="nav-settings__item">Email Settings</div>
                        <div className="nav-settings__item">Sidebar & Footer</div>
                        <div className="nav-settings__item">Home Page</div>
                        <div className="nav-settings__item">Banner</div>
                        <div className="nav-settings__item">Color</div>
                        <div className="nav-settings__item">Other</div>
                    </div>
                    <FavIcon/>
                    <HomePage/>
                </div>
            </div>
        </div>
    </>
};

export default Settings;
