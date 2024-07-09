import React, {useEffect, useState} from 'react';
import { FaArrowAltCircleRight } from "react-icons/fa";
import {generateGUID} from "@/lib/generateGUID";
import axios from "axios";
import {toast} from "react-toastify";

const SocialMedia = () => {

    const [sections, setSections] = useState([]);

    useEffect(() => {
         const fetchSocialMedia = async () => {
             const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Social/GetAllSocial`);

                if(response.data.succeeded){
                    const data = response.data.data.socials;
                    setSections(data);
                }

         }
        fetchSocialMedia();
    }, []);

    const handleInputChange = (id, value) => {
        setSections(prevSections =>
            prevSections.map(section =>
                section.id === id ? { ...section, content: value } : section
            )
        );
    };

    const handleSubmit = async () => {
        const socials = sections.map(section => ({
            id: section.id,
            title: section.title,
            content: section.content
        }));

        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Social/UpdateSocial`, { socials });

            if (response.data.succeeded) {
                toast.success('Social updated successfully');
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
                <h2>Social Media</h2>
            </div>
            <div className="panel-box">
                <div className="panel-box-body">
                    <div className="text-danger mb-4 mt-2 ms-2">
                        If you do not want to show a social media in your front end page, just leave the input field blank.
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


export default SocialMedia;
