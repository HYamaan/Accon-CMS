import React from 'react';
import {MdDashboard, MdHomeRepairService, MdSettings} from "react-icons/md";
import {BsMenuButtonWide} from "react-icons/bs";
import {FaComment, FaLanguage, FaNewspaper, FaQuestionCircle} from "react-icons/fa";
import {FaBoltLightning, FaPhotoFilm} from "react-icons/fa6";
import {IoMenu, IoPersonAdd, IoShareSocialSharp} from "react-icons/io5";
import {RiPagesLine, RiTeamFill} from "react-icons/ri";
import {SiNginxproxymanager} from "react-icons/si";

const AdminNavBar = () => {


    return <aside className={`main-sidebar `}>
        <div>
            <MdDashboard/>
            <h3>Dashboard</h3>
        </div>
        <div>
            <MdSettings/>
            <h3>Settings</h3>
        </div>
        <div>
            <BsMenuButtonWide/>
            <h3>Menu</h3>
        </div>
        <div>
            <MdHomeRepairService/>
            <h3>Service</h3>
        </div>
        <div>
            <FaQuestionCircle/>
            <h3>FAQ</h3>
        </div>
        <div>
            <FaPhotoFilm/>
            <h3>Photo Gallery</h3>
        </div>
        <div>
            <IoMenu/>
            <h3>Portfolio</h3>
        </div>
        <div>
            <RiTeamFill/>
            <h3>Team Member</h3>
        </div>
        <div>
            <IoPersonAdd/>
            <h3>Testimonial</h3>
        </div>
        <div>
            <SiNginxproxymanager/>
            <h3>Partner</h3>
        </div>
        <div>
            <FaBoltLightning/>
            <h3>Why Choose Us</h3>
        </div>
        <div>
            <RiPagesLine/>
            <h3>Page</h3>
        </div>
        <div>
            <FaNewspaper/>
            <h3>News Section</h3>
        </div>
        <div>
            <FaComment />
            <h3>Comment</h3>
        </div>
        <div>
            <FaLanguage />
            <h3>Language</h3>
        </div>
        <div>
            <IoShareSocialSharp />
            <h3>Language</h3>
        </div>
    </aside>
};

export default AdminNavBar;
