import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { MdDashboard, MdHomeRepairService, MdSettings } from "react-icons/md";
import { BsMenuButtonWide } from "react-icons/bs";
import { FaAngleRight, FaComment, FaLanguage, FaNewspaper, FaQuestionCircle, FaRegDotCircle } from "react-icons/fa";
import {FaAngleDown, FaBoltLightning, FaPhotoFilm} from "react-icons/fa6";
import { IoMenu, IoPersonAdd, IoShareSocialSharp } from "react-icons/io5";
import { RiPagesLine, RiTeamFill } from "react-icons/ri";
import { SiNginxproxymanager } from "react-icons/si";
import { setAdminMenuLogoClicked } from '@/redux/features/AdminMenuSlice';
import {GrGallery} from "react-icons/gr";
import {useRouter} from "next/router";

const AdminNavBar = () => {
    const router = useRouter();
    const dispatch = useDispatch();
    const logoClick = useSelector(state => state.adminMenu.adminLogoClicked);
    const menuLogoClick = useSelector(state => state.adminMenu.menuClicked);
    const [openSections, setOpenSections] = useState({});

    const handleMouseEnter = () => {
        if (logoClick && menuLogoClick) {
            dispatch(setAdminMenuLogoClicked(false));
        }
    };

    const handleMouseLeave = () => {
        if (!logoClick && menuLogoClick) {
            console.log("Burada2")
            dispatch(setAdminMenuLogoClicked(true));
        }
    };

    const toggleSection = (section) => {
        setOpenSections(prevState => {
            const newState = {};
            Object.keys(prevState).forEach(key => {
                newState[key] = key === section ? !prevState[key] : false;
            });
            return newState;
        });
    };

    const handleClickRouter = (path) =>{
        router.push(`/admin/${path}`);
    }

    return (
        <aside className={`main-sidebar ${logoClick ? "hidden" : ""}`}>
            <div
                onClick={()=>handleClickRouter('')}
                onMouseLeave={handleMouseLeave}
                className="main-sidebar-item">
                <MdDashboard onMouseEnter={handleMouseEnter}/>
                <h3>Dashboard</h3>
            </div>
            <div
                onClick={()=>handleClickRouter('settings')}
                onMouseLeave={handleMouseLeave}
                 className="main-sidebar-item">
                <MdSettings onMouseEnter={handleMouseEnter}/>
                <h3>Settings</h3>
            </div>
            <div
                onClick={()=>handleClickRouter('menu')}
                onMouseLeave={handleMouseLeave}
                 className="main-sidebar-item">
                <BsMenuButtonWide onMouseEnter={handleMouseEnter}/>
                <h3>Menu</h3>
            </div>
            <div
                onClick={()=>handleClickRouter('slider')}
                onMouseLeave={handleMouseLeave}
                className="main-sidebar-item">
                <GrGallery onMouseEnter={handleMouseEnter}/>
                <h3>Slider</h3>
            </div>
            <div
                onClick={()=>handleClickRouter('service')}
                onMouseLeave={handleMouseLeave}
                className="main-sidebar-item">
                <MdHomeRepairService onMouseEnter={handleMouseEnter}/>
                <h3>Service</h3>
            </div>
            <div onMouseLeave={handleMouseLeave} className="has-sub-pages main-sidebar-item">
                <div className="has-sub-pages-header" onClick={() => toggleSection('faq')}>
                    <div >
                        <FaQuestionCircle onMouseEnter={handleMouseEnter}/>
                        <h3>FAQ</h3>
                    </div>
                    {openSections.faq ? <FaAngleDown/> : <FaAngleRight/>}
                </div>
                <div className={`has-sub-pages-content ${openSections.faq ? 'open' : ''}`}>
                    <div onClick={()=>handleClickRouter("faq")}>
                        <FaRegDotCircle/>
                        <h4>FAQ</h4>
                    </div>
                    <div onClick={()=>handleClickRouter("main-photo")}>
                        <FaRegDotCircle/>
                        <h4>Main Photo</h4>
                    </div>
                </div>
            </div>
            <div onMouseLeave={handleMouseLeave} className="has-sub-pages main-sidebar-item">
                <div className="has-sub-pages-header" onClick={() => toggleSection('photoGallery')}>
                    <div>
                        <FaPhotoFilm onMouseEnter={handleMouseEnter}/>
                        <h3>Photo Gallery</h3>
                    </div>
                    {openSections.photoGallery ? <FaAngleDown/> : <FaAngleRight/>}
                </div>
                <div className={`has-sub-pages-content ${openSections.photoGallery ? 'open' : ''}`}>
                    <div onClick={()=>handleClickRouter("photo-gallery")}>
                        <FaRegDotCircle/>
                        <h4>Photo</h4>
                    </div>
                </div>
            </div>
            <div onMouseLeave={handleMouseLeave} className="has-sub-pages main-sidebar-item">
                <div className="has-sub-pages-header" onClick={() => toggleSection('portfolio')}>
                    <div>
                        <IoMenu onMouseEnter={handleMouseEnter}/>
                        <h3>Portfolio</h3>
                    </div>
                    {openSections.portfolio ? <FaAngleDown/> : <FaAngleRight/>}
                </div>
                <div className={`has-sub-pages-content ${openSections.portfolio ? 'open' : ''}`}>
                    <div onClick={()=>handleClickRouter("portfolio-category")}>
                        <FaRegDotCircle/>
                        <h4>Portfolio Category</h4>
                    </div>
                    <div onClick={()=>handleClickRouter("portfolio")}>
                        <FaRegDotCircle/>
                        <h4>Portfolio</h4>
                    </div>
                </div>
            </div>
            <div onMouseLeave={handleMouseLeave} className="has-sub-pages main-sidebar-item">
                <div className="has-sub-pages-header" onClick={() => toggleSection('teamMember')}>
                    <div>
                        <RiTeamFill onMouseEnter={handleMouseEnter}/>
                        <h3>Team Member</h3>
                    </div>
                    {openSections.teamMember ? <FaAngleDown/> : <FaAngleRight/>}
                </div>
                <div className={`has-sub-pages-content ${openSections.teamMember ? 'open' : ''}`}>
                    <div onClick={()=>handleClickRouter("designation")}>
                        <FaRegDotCircle/>
                        <h4>Designation</h4>
                    </div>
                    <div onClick={()=>handleClickRouter("team-member")}>
                        <FaRegDotCircle/>
                        <h4>Team Member</h4>
                    </div>
                </div>
            </div>
            <div onMouseLeave={handleMouseLeave} className="has-sub-pages main-sidebar-item">
                <div className="has-sub-pages-header" onClick={() => toggleSection('testimonial')}>
                    <div >
                        <IoPersonAdd onMouseEnter={handleMouseEnter}/>
                        <h3>Testimonial</h3>
                    </div>
                    {openSections.testimonial ? <FaAngleDown/> : <FaAngleRight/>}
                </div>
                <div className={`has-sub-pages-content ${openSections.testimonial ? 'open' : ''}`}>
                    <div onClick={()=>handleClickRouter("testimonial")}>
                        <FaRegDotCircle/>
                        <h4>Testimonial</h4>
                    </div>
                    <div onClick={()=>handleClickRouter("main-photo")}>
                        <FaRegDotCircle/>
                        <h4>Main Photo</h4>
                    </div>
                </div>
            </div>
            <div onMouseLeave={handleMouseLeave}>
                <SiNginxproxymanager onMouseEnter={handleMouseEnter}/>
                <h3>Partner</h3>
            </div>
            <div onMouseLeave={handleMouseLeave} className="has-sub-pages main-sidebar-item">
                <div className="has-sub-pages-header" onClick={() => toggleSection('whyChooseUs')}>
                    <div >
                        <FaBoltLightning onMouseEnter={handleMouseEnter}/>
                        <h3>Why Choose Us</h3>
                    </div>
                    {openSections.whyChooseUs ? <FaAngleDown/> : <FaAngleRight/>}
                </div>
                <div className={`has-sub-pages-content ${openSections.whyChooseUs ? 'open' : ''}`}>
                    <div onClick={()=>handleClickRouter("why-choose-us")}>
                        <FaRegDotCircle/>
                        <h4>Why Choose</h4>
                    </div>
                    <div onClick={()=>handleClickRouter("main-photo")}>
                        <FaRegDotCircle/>
                        <h4>Main Photo</h4>
                    </div>
                    <div onClick={()=>handleClickRouter("items-background")}>
                        <FaRegDotCircle/>
                        <h4>Items Background</h4>
                    </div>
                </div>
            </div>
            <div
                onClick={()=>handleClickRouter("page")}
                onMouseLeave={handleMouseLeave}>
                <RiPagesLine onMouseEnter={handleMouseEnter}/>
                <h3>Page</h3>
            </div>
            <div onMouseLeave={handleMouseLeave} className="has-sub-pages main-sidebar-item">
                <div className="has-sub-pages-header" onClick={() => toggleSection('newsSection')}>
                    <div>
                        <FaNewspaper onMouseEnter={handleMouseEnter}/>
                        <h3>News Section</h3>
                    </div>
                    {openSections.newsSection ? <FaAngleDown/> : <FaAngleRight/>}
                </div>
                <div className={`has-sub-pages-content ${openSections.newsSection ? 'open' : ''}`}>
                    <div onClick={()=>handleClickRouter("news-category")}>
                        <FaRegDotCircle/>
                        <h4>News Category</h4>
                    </div>
                    <div onClick={()=>handleClickRouter("news")}>
                        <FaRegDotCircle/>
                        <h4>News</h4>
                    </div>
                </div>
            </div>
            <div
                onClick={()=>handleClickRouter("comment")}
                onMouseLeave={handleMouseLeave} className="main-sidebar-item">
                <FaComment onMouseEnter={handleMouseEnter}/>
                <h3>Comment</h3>
            </div>
            <div
                onClick={()=>handleClickRouter("language")}
                onMouseLeave={handleMouseLeave} className="main-sidebar-item">
                <FaLanguage onMouseEnter={handleMouseEnter}/>
                <h3>Language</h3>
            </div>
            <div
                onClick={()=>handleClickRouter("social-media")}
                onMouseLeave={handleMouseLeave} className="main-sidebar-item">
                <IoShareSocialSharp onMouseEnter={handleMouseEnter}/>
                <h3>Social Media</h3>
            </div>
        </aside>
    );
};

export default AdminNavBar;
