import React, {useEffect, useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import axios from "axios";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";
import {toast} from "react-toastify";

const AddTeamMember = () => {
    const router = useRouter();
    const [name, setName] = useState("");
    const [photo, setPhoto] = useState("");
    const [existPhoto,setExistPhoto] = useState("");
    const [designationName, setDesignationName] = useState("");
    const [facebook, setFacebook] = useState("");
    const [twitter, setTwitter] = useState("");
    const [linkedin, setLinkedin] = useState("");
    const [youtube, setYoutube] = useState("");

    const [designations, setDesignations] = useState([]);
    useEffect(() => {
        const getRoutuerSlider = async () => {
            var id = router.query.Id;
            if (id !== undefined) {
                try {
                    var response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Team/GetEditTeamMember?Id=${id}`);
                    if (response.data.succeeded) {
                        const dataValues = response.data.data;
                        console.log('Data:', dataValues)
                        setName(dataValues.title);
                        setExistPhoto(`/${dataValues.photo}`);
                        setDesignationName(dataValues.designationId);
                        setFacebook(dataValues.facebook);
                        setTwitter(dataValues.twitter);
                        setLinkedin(dataValues.linkedIn);
                        setYoutube(dataValues.youtube);
                    }
                } catch (e) {
                    console.error(e);
                }
            }
        }

        getRoutuerSlider();

    }, [router.query.Id]);

    useEffect(() => {
        const getDesignation = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Team/GetAllDesignation`);
                if (response.data.succeeded) {
                    setDesignations(response.data.data.designation);
                    console.log("Designations:", designations)
                }
            } catch (error) {
                console.error('Error fetching designations:', error);
            }
        }
        getDesignation();
    }, []);
    const handleSubmit =  async (e) => {
        e.preventDefault();
        const formData = new FormData();
        router.query.Id !== undefined && formData.append('Id', router.query.Id);
        formData.append('Title', name);
        formData.append('Designation', designationName);
        photo && formData.append('Image', photo);
        facebook.length> 0 && formData.append('Facebook', facebook);
        twitter && formData.append('Twitter', twitter);
        linkedin && formData.append('LinkedIn', linkedin);
        youtube && formData.append('Youtube', youtube);
        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Team/UpdateTeamMember`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            if (response.data.succeeded) {
                toast.success('Member updated successfully');
                router.push('/admin/team-member');
            } else {
                toast.error(`Error updating ${name} member`);
            }
        } catch (error) {
            toast.error(`Error updating ${name} member`);
            console.error(`Error updating ${name} member`, error);
        }
    }
    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header mb-3">
                    <div className="board-header">
                        <FaArrowAltCircleRight />
                        <h2>Add Slider</h2>
                    </div>
                    <div className="view-border-header__add-view"
                         onClick={() => router.push("/admin/team-member")}
                    >
                        <FaPlus />
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="panel-box-select">
                            <span className="col-md-2">Name *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={name}
                                    onChange={(e) => setName(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Select Designation *</span>
                            <div className="col-md-10">
                                <select
                                    value={designationName}
                                    onChange={(e) => setDesignationName(e.target.value)}
                                >
                                    {
                                        designationName.length === 0 && <option value="">Select Designation</option>
                                    }
                                    {
                                        designations.map((designation, index) => (
                                         <option key={index} value={designation.id}>{designation.title}</option>
                                        ))
                                    }
                                </select>
                            </div>
                        </div>
                        {
                            existPhoto && <div className="panel-box-select">
                                <span className="col-md-2">Existing Photo</span>
                                <div className="col-md-10">
                                    <div className="panel-website-icon-show">
                                        <LazyLoadImage src={existPhoto}/>
                                    </div>
                                </div>
                            </div>
                        }
                        <div className="panel-box-select">
                            <span className="col-md-2">New Photo</span>
                            <div className="col-md-10">
                                <div className="panel-website-icon-show">
                                    <OneFileUpload file={photo} setFile={setPhoto}/>
                                </div>
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Facebook *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={facebook}
                                    onChange={(e) => setFacebook(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Twitter *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={twitter}
                                    onChange={(e) => setTwitter(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Linkedin *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={linkedin}
                                    onChange={(e) => setLinkedin(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="panel-box-select">
                            <span className="col-md-2">Google *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={youtube}
                                    onChange={(e) => setYoutube(e.target.value)}
                                />
                            </div>
                        </div>

                        <div className="panel-box-select ps-md-3">
                            <div className="col-md-2"></div>
                            <div className="col-md-10">
                                <button onClick={handleSubmit}
                                        className="secondary-button panel-website-icon-show__button">Update
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default AddTeamMember;
