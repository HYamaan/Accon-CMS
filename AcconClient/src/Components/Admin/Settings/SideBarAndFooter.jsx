import React, { useState } from 'react';
import { FaArrowAltCircleRight } from "react-icons/fa";
import {generateGUID} from "@/lib/generateGUID";

const SideBarAndFooter = () => {
    const initialSections = [
        { id: generateGUID(), key: "How many recent posts?", value: "4" },
        { id: generateGUID(), key: "How many popular posts?", value: "4" }
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
        <div className="content-wrapper bg-white">

                    {sections.map(section => (
                        <div className="panel-box-select" key={section.id}>
                            <span className="col-md-4">{section.key}</span>
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
    );
};


export default SideBarAndFooter;
