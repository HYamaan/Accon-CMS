import React, { useState } from 'react';
import { FaArrowAltCircleRight } from "react-icons/fa";
import {generateGUID} from "@/lib/generateGUID";

const SocialMedia = () => {
    const initialSections = [
        { id: generateGUID(), key: "Facebook", value: "#" },
        { id: generateGUID(), key: "Twitter", value: "#" },
        { id: generateGUID(), key: "LinkedIn", value: "#" },
        { id: generateGUID(), key: "Google Plus", value: "#" },
        { id: generateGUID(), key: "Pinterest", value: "#" },
        { id: generateGUID(), key: "YouTube", value: "" },
        { id: generateGUID(), key: "Instagram", value: "" },
        { id: generateGUID(), key: "Tumblr", value: "" },
        { id: generateGUID(), key: "Flickr", value: "" },
        { id: generateGUID(), key: "Reddit", value: "" },
        { id: generateGUID(), key: "Snapchat", value: "" },
        { id: generateGUID(), key: "WhatsApp", value: "" },
        { id: generateGUID(), key: "Quora", value: "" },
        { id: generateGUID(), key: "StumbleUpon", value: "" },
        { id: generateGUID(), key: "Delicious", value: "" },
        { id: generateGUID(), key: "Digg", value: "" }
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
                <h2>Social Media</h2>
            </div>
            <div className="panel-box">
                <div className="panel-box-body">
                    <div className="text-danger mb-4 mt-2 ms-2">
                        If you do not want to show a social media in your front end page, just leave the input field blank.
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


export default SocialMedia;
