import React, {useState} from 'react';
import {useRouter} from "next/router";
import {FaArrowAltCircleRight, FaPlus} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";

const AddTeamMember = (props) => {
    const router = useRouter();
    const [name, setName] = useState("");
    const [photo, setPhoto] = useState("/photo-1.jpg");
    const [designationName, setDesignationName] = useState(true);
    const [facebook, setFacebook] = useState("");
    const [twitter, setTwitter] = useState("");
    const [linkedin, setLinkedin] = useState("");
    const [google, setGoogle] = useState("");
    const handleSubmit = () => {
        console.log(name, photo, designationName);
        // İsteği göndermek veya başka işlemler yapmak için burada kod ekleyin.
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
                                    <option value="chairman">Chairman</option>
                                    <option value="enginner">Enginner</option>
                                    <option value="manager">Manager</option>
                                    <option value="worker">Worker</option>
                                </select>
                            </div>
                        </div>
                        {
                            props?.existPhoto && <div className="panel-box-select">
                                <span className="col-md-2">Existing Photo</span>
                                <div className="col-md-10">
                                    <div className="panel-website-icon-show">
                                        <LazyLoadImage src={photo}/>
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
                                    value={google}
                                    onChange={(e) => setGoogle(e.target.value)}
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
