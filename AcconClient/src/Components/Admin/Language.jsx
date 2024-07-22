import React, {useEffect, useState} from 'react';
import { FaArrowAltCircleRight } from "react-icons/fa";
import {generateGUID} from "@/lib/generateGUID";
import axios from "axios";
import {toast} from "react-toastify";

const Language = () => {
    const [sections, setSections] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Language/GetAllLanguages`);

                if(response.data.succeeded){
                    const data = response.data.data.languages;
                    setSections(data);
                }

            }catch (error) {
                toast.error('Error: ' + error.message);
                console.error('Error:', error);
            }
        }
        fetchData()
    }, []);


    const handleInputChange = (id, content) => {
        setSections(prevSections =>
            prevSections.map(section =>
                section.id === id ? { ...section, content: content } : section
            )
        );
    };

    const handleSubmit = async () => {
        const languages = sections.map(section => ({
            id: section.id,
            title: section.title,
            content: section.content // section.value yerine section.content kullanıldı
        }));

        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Language/UpdateLanguage`, { languages });

            if (response.data.succeeded) {
                toast.success('Language updated successfully');
            } else {
                toast.error('Error: ' + response.data.message);
            }
        } catch (error) {
            toast.error('Error: ' + error.message);
            console.error('Error:', error);
        }
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
                            <span className="col-md-4 ">{section.title}</span>
                            <div className="col-md-8">
                                <input
                                    type="text"
                                    value={section.content}
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
