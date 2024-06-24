import {useRouter} from 'next/router';
import React, {useState} from 'react';
import {LazyLoadImage} from 'react-lazy-load-image-component';
import {IoMenu} from "react-icons/io5";

const AdminHeader = () => {
    const [logoHidden, setLogoHidden] = useState(false);
    const router = useRouter();

    const toggleLogo = () => {
        setLogoHidden(!logoHidden);
    };
    const getMainPage = async () => {
        await router.push("/");
    }

    return <header className='main-header'>
        <div className={`main-header__logo ${logoHidden ? 'hidden' : ''}`}>
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
