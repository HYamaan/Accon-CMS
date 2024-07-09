import React, {useEffect, useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight} from "react-icons/fa";
import HomePageInfo from "@/Components/Admin/Pages/HomePageInfo";
import AboutPageInfo from "@/Components/Admin/Pages/AboutPageInfo";
import GalleryPageInfo from "@/Components/Admin/Pages/GalleryPageInfo";
import FaqPageInfo from "@/Components/Admin/Pages/FaqPageInfo";
import ServicePageInfo from "@/Components/Admin/Pages/ServicePageInfo";
import PortfolioPageInfo from "@/Components/Admin/Pages/PortfolioPageInfo";
import TestimonialPageInfo from "@/Components/Admin/Pages/TestimonialPageInfo";
import NewsPageInfo from "@/Components/Admin/Pages/NewsPageInfo";
import ContactPageInfo from "@/Components/Admin/Pages/ContactPageInfo";
import TermsPageInfo from "@/Components/Admin/Pages/TermsPageInfo";
import PrivacyPageInfo from "@/Components/Admin/Pages/PrivacyPageInfo";
import axios from "axios";

const Page =({ slug, combinedSlug }) => {
    const router = useRouter();
    const [activeTab, setActiveTab] = useState(slug[1] || "");
    const [pages, setPages] = useState([]);

    useEffect(() => {
        setActiveTab(slug[1] || "");
    }, [slug]);


    const handleClickRouter = (path) => {
        setActiveTab(path);
        router.push(`/admin/page/${path}`);
    };

    return (
        <>
            <div className="content-wrapper">
                <div className="board-header">
                    <FaArrowAltCircleRight />
                    <h2>Page Section</h2>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="nav-settings">
                            <div
                                onClick={() => handleClickRouter("")}
                                className={`nav-settings__item ${activeTab === "" ? "active" : ""}`}
                            >
                                Home
                            </div>
                            <div
                                onClick={() => handleClickRouter("about")}
                                className={`nav-settings__item ${activeTab === "about" ? "active" : ""}`}
                            >
                                About
                            </div>
                            <div
                                onClick={() => handleClickRouter("gallery")}
                                className={`nav-settings__item ${activeTab === "gallery" ? "active" : ""}`}
                            >
                                Gallery
                            </div>
                            <div
                                onClick={() => handleClickRouter("faq")}
                                className={`nav-settings__item ${activeTab === "faq" ? "active" : ""}`}
                            >
                                FAQ
                            </div>
                            <div
                                onClick={() => handleClickRouter("service")}
                                className={`nav-settings__item ${activeTab === "service" ? "active" : ""}`}
                            >
                                Service
                            </div>
                            <div
                                onClick={() => handleClickRouter("portfolio")}
                                className={`nav-settings__item ${activeTab === "portfolio" ? "active" : ""}`}
                            >
                                Portfolio
                            </div>
                            <div
                                onClick={() => handleClickRouter("testimonial")}
                                className={`nav-settings__item ${activeTab === "testimonial" ? "active" : ""}`}
                            >
                                Testimonial
                            </div>
                            <div
                                onClick={() => handleClickRouter("news")}
                                className={`nav-settings__item ${activeTab === "news" ? "active" : ""}`}
                            >
                                News
                            </div>
                            <div
                                onClick={() => handleClickRouter("contact")}
                                className={`nav-settings__item ${activeTab === "contact" ? "active" : ""}`}
                            >
                                Contact
                            </div>
                            <div
                                onClick={() => handleClickRouter("terms")}
                                className={`nav-settings__item ${activeTab === "terms" ? "active" : ""}`}
                            >
                                Terms
                            </div>
                            <div
                                onClick={() => handleClickRouter("privacy")}
                                className={`nav-settings__item ${activeTab === "privacy" ? "active" : ""}`}
                            >
                                Privacy
                            </div>
                        </div>
                        {slug[0] === "page" && !slug[1] && <HomePageInfo/>}
                        {slug[1] === "about" && <AboutPageInfo/>}
                        {slug[1] === "gallery" && <GalleryPageInfo/>}
                        {slug[1] === "faq" && <FaqPageInfo/>}
                        {slug[1] === "service" && <ServicePageInfo />}
                        {slug[1] === "portfolio" && <PortfolioPageInfo />}
                        {slug[1] === "testimonial" && <TestimonialPageInfo />}
                        {slug[1] === "news" && <NewsPageInfo />}
                        {slug[1] === "contact" && <ContactPageInfo />}
                        {slug[1] === "terms" && <TermsPageInfo />}
                        {slug[1] === "privacy" && <PrivacyPageInfo />}
                    </div>
                </div>
            </div>
        </>
    );
};

export default Page;
