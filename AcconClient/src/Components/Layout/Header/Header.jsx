import React, {useEffect, useState} from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import {FaAngleDown} from "react-icons/fa6";
import {MdOutlineEmail} from "react-icons/md";
import {IoCall} from "react-icons/io5";
import {FaFacebookF, FaInstagram, FaLinkedinIn, FaPlus, FaTwitter} from "react-icons/fa";
import {ImGooglePlus} from "react-icons/im";
import Link from "next/link";
import {useRouter} from "next/router";

const Header = () => {
    const router = useRouter();
    const [isFixed, setIsFixed] = useState(false);
    const [isChanged, setIsChanged] = useState(false);
    const [openSubMenu, setOpenSubMenu] = useState(false);
    useEffect(() => {
        const handleScroll = () => {
            const navSection = document.querySelector('.nav-section');
            if (navSection) {
                const scrollTop = window.scrollY;
                if (scrollTop > 47) {
                    setIsFixed(true);
                } else {
                    setIsFixed(false);
                }
            }
        };

        window.addEventListener('scroll', handleScroll);

        return () => {
            window.removeEventListener('scroll', handleScroll);
        };
    }, []);
    const handleClick = () => {
        setIsChanged(!isChanged);
        setOpenSubMenu(false);
    };
    const handleClickSubMenu = () => {
        setOpenSubMenu(!openSubMenu);
    }

    return (
        <>
            <div className="mean-section">
                <div className="mean-bar">
                    <h3>Menu</h3>
                    <div className={`bar-container ${isChanged ? 'change' : ''}`} onClick={handleClick}>
                        <div className="bar1"></div>
                        <div className="bar2"></div>
                        <div className="bar3"></div>
                    </div>
                </div>
                <div className={`menu-bar ${isChanged ? 'open' : ''}`}>
                    <div><Link href={"/"}>Home</Link></div>
                    <div className="menu-bar-pages">
                        <Link href={"/"}>
                            Page
                            <FaPlus onClick={handleClickSubMenu}/>
                        </Link>
                        <div className={`menu-bar-pages-sub ${
                            openSubMenu ? 'open' : ''
                        }`}>
                            <div><Link href={"/about"}>About</Link></div>
                            <div><Link href={"/gallery"}>Gallery</Link></div>
                            <div><Link href={"/faq"}>FAQ</Link></div>
                        </div>
                    </div>
                    <div><Link href={"/service"}>Service</Link></div>
                    <div><Link href={"/portfolio"}>Portfolio</Link></div>
                    <div><Link href={"/testimonial"}>Testimonial</Link></div>
                    <div><Link href={"/news"}>News</Link></div>
                    <div><Link href={"/contact"}>Contact</Link></div>
                </div>
            </div>
            <div className="header-area">
                <div className="container">
                    <div className="row">
                        <div className="col-md-8 col-sm-8">
                            <ul className="header-contact">
                                <li>
                                    <a href="mailto:info@yourdomain.com">
                                        <MdOutlineEmail/>
                                        <span>info@yourdomain.com</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="tel:123-456-7878">
                                        <IoCall/>
                                        <span>123-456-7878</span>
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div className="col-md-4 col-sm-4">
                            <div className="header-links">
                                <a href="https://www.facebook.com" target="_blank"
                                   rel="noopener noreferrer">
                                    <FaFacebookF/>
                                </a>
                                <a href="https://twitter.com" target="_blank" rel="noopener noreferrer">
                                    <FaTwitter/>
                                </a>
                                <a href="https://www.instagram.com" target="_blank"
                                   rel="noopener noreferrer">
                                    <FaInstagram/>
                                </a>
                                <a href="https://www.linkedin.com" target="_blank"
                                   rel="noopener noreferrer">
                                    <FaLinkedinIn/>
                                </a>
                                <a href="https://plus.google.com" target="_blank"
                                   rel="noopener noreferrer">
                                    <ImGooglePlus/>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className={`nav-section ${isFixed ? 'fixed' : ''}`}>
                <div className="container">
                    <div className="row">
                        <div className="col-md-3 col-sm-12 logo-section">
                            <LazyLoadImage
                                alt="logo"
                                src={"/logo.png"}
                                className="nav-logo"
                                onClick={() => router.push('/')}
                            />

                        </div>
                        <div className="col-md-9 col-sm-12 menu-section">
                            <ul className="nav-menu d-flex">
                                <li onClick={() => router.push('/')}>Home</li>
                                <li className="nav-pages">
                                    Page
                                    <FaAngleDown className="nav-icon"/>
                                    <ul className="sub-menu">
                                        <li onClick={() => router.push('/about')}>About</li>
                                        <li onClick={() => router.push('/gallery')}>Gallery</li>
                                        <li onClick={() => router.push('/faq')}>FAQ</li>
                                    </ul>
                                </li>
                                <li onClick={() => router.push('/service')}>Service</li>
                                <li onClick={() => router.push('/portfolio')}>PORTFOLIO</li>
                                <li onClick={() => router.push('/testimonial')}>TESTIMONIAL</li>
                                <li onClick={() => router.push('/news')}>NEWS</li>
                                <li onClick={() => router.push('/contact')}>CONTACT</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default Header;
