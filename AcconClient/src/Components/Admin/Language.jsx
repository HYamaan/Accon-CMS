import React, { useState } from 'react';
import { FaArrowAltCircleRight } from "react-icons/fa";
import {generateGUID} from "@/lib/generateGUID";

const Language = () => {
    const initialSections = [
        { id: generateGUID(), key: "ABOUT", value: "About" },
        { id: generateGUID(), key: "ABOUT_US", value: "About Us" },
        { id: generateGUID(), key: "ADDRESS", value: "Address" },
        { id: generateGUID(), key: "ADMIN", value: "Admin" },
        { id: generateGUID(), key: "ALL", value: "All" },
        { id: generateGUID(), key: "CALL_US", value: "Call Us" },
        { id: generateGUID(), key: "CATEGORY", value: "Category" },
        { id: generateGUID(), key: "CLIENT_COMMENT", value: "Client's Comment" },
        { id: generateGUID(), key: "CLIENT_COMPANY", value: "Client Company" },
        { id: generateGUID(), key: "CLIENT_NAME", value: "Client Name" },
        { id: generateGUID(), key: "COMMENTS", value: "Comments" },
        { id: generateGUID(), key: "CONTACT", value: "Contact" },
        { id: generateGUID(), key: "CONTACT_FORM_EMAIL_SUBJECT", value: "Contact Form Email - YourWebsite.com" },
        { id: generateGUID(), key: "CONTACT_FORM_EMAIL_SUCCESS_MESSAGE", value: "Thank you for sending us the email. We will contact you shortly." },
        { id: generateGUID(), key: "CONTACT_US_PAGE_FORM_HEADING_TEXT", value: "Contact us through the following form:" },
        { id: generateGUID(), key: "DESCRIPTION", value: "Description" },
        { id: generateGUID(), key: "EMAIL_ADDRESS", value: "Email Address" },
        { id: generateGUID(), key: "EMPTY_ERROR_COMMENT", value: "Comment can not be empty" },
        { id: generateGUID(), key: "EMPTY_ERROR_EMAIL", value: "Email address can not be empty" },
        { id: generateGUID(), key: "EMPTY_ERROR_NAME", value: "Name can not be empty" },
        { id: generateGUID(), key: "EMPTY_ERROR_PHONE", value: "Phone number can not be empty" },
        { id: generateGUID(), key: "FAQ", value: "FAQ" },
        { id: generateGUID(), key: "FIND_US_ON_MAP", value: "Find Us on Map:" },
        { id: generateGUID(), key: "GALLERY", value: "Gallery" },
        { id: generateGUID(), key: "HOME", value: "Home" },
        { id: generateGUID(), key: "LATEST_NEWS", value: "Latest News" },
        { id: generateGUID(), key: "MESSAGE", value: "Message" },
        { id: generateGUID(), key: "NAME", value: "Name" },
        { id: generateGUID(), key: "NEWS", value: "News" },
        { id: generateGUID(), key: "NEXT", value: "Next" },
        { id: generateGUID(), key: "NO_RESULT_FOUND", value: "No Result Found" },
        { id: generateGUID(), key: "PAGE", value: "Page" },
        { id: generateGUID(), key: "PASSWORD_REQUEST_EMAIL_SUBJECT", value: "Password Request - yourwebsite.com" },
        { id: generateGUID(), key: "PHONE", value: "Phone Number" },
        { id: generateGUID(), key: "POPULAR_NEWS", value: "Popular News" },
        { id: generateGUID(), key: "PORTFOLIO", value: "Portfolio" },
        { id: generateGUID(), key: "POSTED_ON", value: "Posted On:" },
        { id: generateGUID(), key: "PREVIOUS", value: "Previous" },
        { id: generateGUID(), key: "PRIVACY_POLICY", value: "Privacy Policy" },
        { id: generateGUID(), key: "PROJECT_END_DATE", value: "Project End Date" },
        { id: generateGUID(), key: "PROJECT_START_DATE", value: "Project Start Date" },
        { id: generateGUID(), key: "PROJECTS", value: "Projects" },
        { id: generateGUID(), key: "QUICK_LINKS", value: "Quick Links" },
        { id: generateGUID(), key: "READ_MORE", value: "Read More" },
        { id: generateGUID(), key: "SEARCH_BY", value: "Search By:" },
        { id: generateGUID(), key: "SEARCH_NEWS", value: "Search News" },
        { id: generateGUID(), key: "SEND_MESSAGE", value: "Send Message" },
        { id: generateGUID(), key: "SERVICE", value: "Service" },
        { id: generateGUID(), key: "SERVICES", value: "Services" },
        { id: generateGUID(), key: "SHARE_THIS", value: "Share This" },
        { id: generateGUID(), key: "TERMS_AND_CONDITIONS", value: "Terms and Conditions" },
        { id: generateGUID(), key: "TESTIMONIAL", value: "Testimonial" },
        { id: generateGUID(), key: "VALID_ERROR_EMAIL", value: "Email address is invalid" },
        { id: generateGUID(), key: "WORKING_HOURS", value: "Working Hours" }
    ];

    const [sections, setSections] = useState(initialSections);

    const handleInputChange = (id, value) => {
        setSections(prevSections =>
            prevSections.map(section =>
                section.id === id ? { ...section, value: value } : section
            )
        );
    };

    const handleSubmit = () => {
        const selectedSections = sections.map(section => ({
            id: section.id,
            key: section.key,
            value: section.value
        }));

        // API'ye gönderme işlemi
        console.log('Submit:', selectedSections);
        // fetch('/api/submit', { method: 'POST', body: JSON.stringify(selectedSections) })
    };

    return (
        <div className="content-wrapper">
            <div className="board-header">
                <FaArrowAltCircleRight />
                <h2>Language</h2>
            </div>
            <div className="panel-box">
                <div className="panel-box-body">
                    <div className="text-danger mb-4 mt-2 ms-2">
                        NB: In this section, you will be able to change those text in your language that are not possible to change from other sections.
                    </div>
                    {sections.map(section => (
                        <div className="panel-box-select" key={section.id}>
                            <span className="col-md-4 ">{section.key}</span>
                            <div className="col-md-8">
                                <input
                                    type="text"
                                    value={section.value}
                                    onChange={(e) => handleInputChange(section.id, e.target.value)}
                                />
                            </div>
                        </div>
                    ))}
                    <div className="panel-box-select ps-md-3">
                        <div className="col-md-4"></div>
                        <div className="col-md-8">
                            <button onClick={handleSubmit} className="secondary-button">Submit</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};



export default Language;
