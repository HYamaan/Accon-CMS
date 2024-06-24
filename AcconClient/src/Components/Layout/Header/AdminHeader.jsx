import {useRouter} from 'next/router';
import React, {useEffect, useState} from 'react';
import {LazyLoadImage} from 'react-lazy-load-image-component';
import {IoMenu} from "react-icons/io5";
import {useDispatch, useSelector} from "react-redux";
import {setAdminMenuLogoClicked, setMenuLogoClicked} from "@/redux/features/AdminMenuSlice";

const AdminHeader = () => {
    const selectorLogo = useSelector(state => state.adminMenu.adminLogoClicked);
    const router = useRouter();
    const dispatch = useDispatch();

    const toggleLogo = () => {
        dispatch(setAdminMenuLogoClicked(!selectorLogo));
        dispatch(setMenuLogoClicked(!selectorLogo));
    };
    const getMainPage = async () => {
        await router.push("/");
    }

    return <header className='main-header'>
        <div className={`main-header__logo ${selectorLogo ? 'hidden' : ''}`}>
            <LazyLoadImage
                src={"/logo_admin.png"}
                alt="logo_admin"
            />
        </div>
        <div className="main-header__navbar">
            <div className="main-header__navbar-left" onClick={toggleLogo}>
                <IoMenu/>
                <div>Admin Panel</div>
            </div>
            <div className="main-header__navbar-right">
                <div onClick={getMainPage} className="visit_website">
                    Visit Website
                </div>
                <div className="user_info">
                    <LazyLoadImage
                        src={"team-member-2.jpg"}
                        alt={"team-member-2.jpg"}/>
                    <span>John Doe</span>
                </div>
            </div>
        </div>
    </header>
};

export default AdminHeader;
