import React, { useEffect, useState } from 'react';
import { FaArrowAltCircleRight } from "react-icons/fa";
import axios from "axios";
import {toast} from "react-toastify";

const Menu = () => {
    const options = [
        { label: "Show", value: true },
        { label: "Hide", value: false }
    ];
    const [sections, setSections] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchPageSections = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Menu/GetPageInformation`);
                if (response.data.succeeded) {
                    console.log(response.data.data.pages);
                    setSections(response.data.data.pages);
                }
            } catch (error) {
                console.error('Error fetching page sections:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchPageSections();
    }, []);

    const handleSelectChange = (id, value) => {
        setSections(prevSections =>
            prevSections.map(section =>
                section.id === id ? { ...section, isPublished: value } : section
            )
        );
    };

    useEffect(() => {
        console.log('Sections:', sections);
    }, [sections]);

    const handleSubmit = async () => {
        const selectedSections = sections.map(section => ({
            id: section.id,
            isPublished: section.isPublished
        }));
        const data = {
            "pages": selectedSections
        }
        const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Menu/UpdateMenuInformation`, data,{ withCredentials: true }   );
        if(response.data.succeeded){
            toast.success("Menu updated successfully");
        }else{
            toast.error("Error updating menu");
        }

    };

    return (
        <div className="content-wrapper">
            <div className="board-header">
                <FaArrowAltCircleRight />
                <h2>Menu</h2>
            </div>
            <div className="panel-box">
                <div className="panel-box-body">
                    {loading ? (
                        <div>Loading...</div>
                    ) : (
                        <>
                            {sections.map(section => (
                                <div className="panel-box-select" key={section.id}>
                                    <span className="col-md-4 ">{section.page}</span>
                                    <div className="col-md-8">
                                        <select
                                            value={section.isPublished}
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
                        </>
                    )}
                </div>
            </div>
        </div>
    );
};

export default Menu;
