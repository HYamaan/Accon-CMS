import React, {useState} from 'react';
import {FaArrowAltCircleRight} from "react-icons/fa";
import {generateGUID} from "@/lib/generateGUID";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";

const GeneralContent = () => {
    const initialSections = [
        { id: generateGUID(), name: "Footer - Copyright", value: "Copyright 2023. All Rights Reserved.", type: "input" },
        { id: generateGUID(), name: "Footer - Address", value: "Lane A21, ABC Steet, \nNewYork, USA.", type: "textarea" },
        { id: generateGUID(), name: "Footer - Phone", value: "111-222-3333\n111-222-4444", type: "textarea" },
        { id: generateGUID(), name: "Footer - Working Hour", value: "Monday-Friday (9:00 AM - 5:00 PM)\nSaturday and Sunday: Off", type: "textarea" },
        { id: generateGUID(), name: "Footer - About us", value: "Lorem ipsum dolor sit amet, omnis signiferumque in mei, mei ex enim concludaturque. Senserit salutandi euripidis no per, modus maiestatis scribentur est an. Ea suas pertinax has, solet officiis pericula cu pro, possit inermis qui ad. An mea tale perfecto sententiae.", type: "textarea" },
        { id: generateGUID(), name: "Top Bar Email", value: "info@yourdomain.com", type: "input" },
        { id: generateGUID(), name: "Top Bar Phone Number", value: "123-456-7878", type: "input" },
        { id: generateGUID(), name: "Contact Map iFrame", value: '<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d387142.84040262736!2d-74.25819605476612!3d40.70583158628177!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x89c24fa5d33f083b%3A0xc80b8f06e177fe62!2sNew+York%2C+NY%2C+USA!5e0!3m2!1sen!2sbd!4v1485712851643" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>', type: "textarea" }
    ];

    const [sections, setSections] = useState(initialSections);
    const [footerAddressIcon,setFooterAddressIcon] = useState(null);
    const [footerPhoneIcon,setFooterPhoneIcon] = useState(null);
    const [footerWorkingHourIcon,setFooterWorkingHourIcon] = useState(null);
    const footerAddressIconTitle = "Footer Address Icon";
    const footerPhoneIconTitle = "Footer Phone Icon";
    const footerWorkingHourIconTitle = "Footer Working Hour Icon";

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
            name: section.name,
            value: section.value
        }));

        // API'ye gönderme işlemi
        console.log('Submit:', selectedSections);
        // fetch('/api/submit', { method: 'POST', body: JSON.stringify(selectedSections) })
    };

    return (
        <div className="content-wrapper bg-white">
                    <div className="text-danger mb-4 mt-2 ms-2">
                        If you do not want to show a social media in your front end page, just leave the input field blank.
                    </div>
                    {sections.map(section => (
                        <div className="panel-box-select" key={section.id}>
                            <span className="col-md-4 ">{section.name}</span>
                            <div className="col-md-8">
                                {section.type === "input" ? (
                                    <input
                                        type="text"
                                        value={section.value}
                                        onChange={(e) => handleInputChange(section.id, e.target.value)}
                                    />
                                ) : (
                                    <textarea
                                        rows="5"
                                        value={section.value}
                                        onChange={(e) => handleInputChange(section.id, e.target.value)}
                                    />
                                )}
                            </div>
                        </div>
                    ))}
                    <div className="panel-box-select ps-md-3">
                        <div className="col-md-4"></div>
                        <div className="col-md-8">
                            <button onClick={handleSubmit} className="secondary-button">Submit</button>
                        </div>
                    </div>

                    <UploadLogoComponent logoFile={footerAddressIcon}
                    setLogoFile={setFooterAddressIcon}
                    title={footerAddressIconTitle}/>
                    <UploadLogoComponent logoFile={footerPhoneIcon}
                    setLogoFile={setFooterPhoneIcon}
                    title={footerPhoneIconTitle}/>
                    <UploadLogoComponent logoFile={footerWorkingHourIcon}
                    setLogoFile={setFooterWorkingHourIcon}
                    title={footerWorkingHourIconTitle}/>

        </div>
    );
};


export default GeneralContent;
