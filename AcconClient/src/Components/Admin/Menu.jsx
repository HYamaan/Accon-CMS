import React, { useState } from 'react';
import { FaArrowAltCircleRight } from "react-icons/fa";
import {generateGUID} from "@/lib/generateGUID";

const Menu = () => {
    const options = [
        { label: "Show", value: true },
        { label: "Hide", value: false }
    ];

    const initialSections = [
        { id: generateGUID(), name: "Home", selected: true },
        { id: generateGUID(), name: "About", selected: true },
        { id: generateGUID(), name: "Gallery", selected: true },
        { id: generateGUID(), name: "FAQ", selected: true },
        { id: generateGUID(), name: "Service", selected: true },
        { id: generateGUID(), name: "Portfolio", selected: true },
        { id: generateGUID(), name: "Testimonial", selected: true },
        { id: generateGUID(), name: "News", selected: true },
        { id: generateGUID(), name: "Contact", selected: true },


    ];

    const [sections, setSections] = useState(initialSections);

    const handleSelectChange = (id, value) => {
        setSections(prevSections =>
            prevSections.map(section =>
                section.id === id ? { ...section, selected: value } : section
            )
        );
    };

    const handleSubmit = () => {
        const selectedSections = sections.map(section => ({
            id: section.id,
            name: section.name,
            selected: section.selected
        }));

        // API'ye gönderme işlemi
        console.log('Submit:', selectedSections);
        // fetch('/api/submit', { method: 'POST', body: JSON.stringify(selectedSections) })
    };

    return (
        <div className="content-wrapper">
            <div className="board-header">
                <FaArrowAltCircleRight />
                <h2>Menu</h2>
            </div>
            <div className="panel-box">
                <div className="panel-box-body">
                    {sections.map(section => (
                        <div className="panel-box-select" key={section.id}>
                            <span className="col-md-4 ">{section.name}</span>
                            <div className="col-md-8">
                                <select
                                    value={section.selected}
                                    onChange={(e) => handleSelectChange(section.id, e.target.value === 'true')}
                                >
                                    {options.map(option => (
                                        <option key={option.label} value={option.value.toString()}>
                                            {option.label}
                                        </option>
                                    ))}
                                </select>
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


export default Menu;
