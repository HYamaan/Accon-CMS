import React, {useEffect, useState} from 'react';
import { useRouter } from "next/router";
import { FaArrowAltCircleRight, FaPlus } from "react-icons/fa";
import { LazyLoadImage } from "react-lazy-load-image-component";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import axios from "axios";
import process from "next/dist/build/webpack/loaders/resolve-url-loader/lib/postcss";
import {toast} from "react-toastify";
import {VisibilityPlaceEnum} from "@/data/enum/VisibilityPlaceEnum";

const AddPhotoGallery = () => {
    const router = useRouter();
    const [caption, setCaption] = useState("");
    const [photo, setPhoto] = useState("");
    const [visiblePlace, setVisiblePlace] = useState("");
    const [existingPhoto, setExistingPhoto] = useState("");

    useEffect(() => {
        const getRouterSlider = async () => {
            const id = router.query.Id;
            if (id) {
                try {
                    const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Gallery/GetEditGallery?Id=${id}`);
                    if (response.data.succeeded) {
                        const dataValues = response.data.data;
                        setCaption(dataValues.title);
                        setExistingPhoto(`/${dataValues.photo}`);
                        setVisiblePlace(dataValues.visiblePlace.toString());
                    }
                } catch (error) {
                    console.error('Error fetching photo gallery:', error);
                }
                console.log('Photo Gallery:', caption, photo, visiblePlace, existingPhoto)
            }
        };
        getRouterSlider();
    }, [router.query.Id]); // Corrected dependency
    const handleSubmit =  async (e) => {
        e.preventDefault();

        const formData = new FormData();
        router.query.Id !== undefined && formData.append('Id', router.query.Id);
        formData.append('Title', caption);
        console.log("photoLength",photo.length)
        photo.length > 0 && formData.append('Photo', photo);
        formData.append('VisiblePlace', visiblePlace);

        try {
            const response = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Gallery/UpdateGallery`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            if (response.data.succeeded) {
                toast.success('Gallery updated successfully');
                router.push('/admin/photo-gallery');
            } else {
                toast.error(`Error updating ${caption} service`);
            }
        } catch (error) {
            console.error(`Error updating ${caption} service`, error);
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
                         onClick={() => router.push("/admin/photo-gallery")}
                    >
                        <FaPlus />
                        <span>View All</span>
                    </div>
                </div>
                <div className="panel-box">
                    <div className="panel-box-body">
                        <div className="panel-box-select">
                            <span className="col-md-2">Photo Caption *</span>
                            <div className="col-md-10">
                                <input
                                    type="text"
                                    value={caption}
                                    onChange={(e) => setCaption(e.target.value)}
                                />
                            </div>
                        </div>
                        {
                            router.query.Id !== undefined && (
                                <div className="panel-box-select">
                                    <span className="col-md-2">Existing Photo</span>
                                    <div className="col-md-10">
                                        <div className="panel-website-icon-show">
                                            <LazyLoadImage src={existingPhoto}/>
                                        </div>
                                    </div>
                                </div>
                            )
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
                            <span className="col-md-2">Show on home? *</span>
                            <div className="col-md-10">
                                <select
                                    value={visiblePlace}
                                    onChange={(e) => setVisiblePlace(e.target.value)}
                                >
                                    {Object.entries(VisibilityPlaceEnum).map(([key, value]) => (
                                        <option key={key} value={key}>{value}</option>
                                    ))}
                                </select>
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

export default AddPhotoGallery;
