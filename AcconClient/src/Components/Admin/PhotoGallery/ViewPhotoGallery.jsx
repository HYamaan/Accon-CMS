import React, {useEffect, useState} from 'react';
import {useMediaQuery} from "react-responsive";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {Table, Tbody, Td, Th, Thead, Tr} from "react-super-responsive-table";
import {useRouter} from "next/router";
import axios from "axios";
import {toast} from "react-toastify";

import {VisibilityPlaceEnum} from "@/data/enum/VisibilityPlaceEnum";
const ViewPhotoGallery = () => {
    const router = useRouter();
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });

    const [photoGallery, setPhotoGallery] = useState([]);
    const [tempPhotoGallery, setTempPhotoGallery] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Gallery/GetAllGallery`);
                if (response.data.succeeded) {
                    setPhotoGallery(response.data.data.gallery);
                    const filteredKeys = Object.keys(response.data.data.photoGallery[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                }
            } catch (error) {
                console.error('Error fetching photoGallery:', error);
            } finally {
                setLoading(false);
            }
            console.log('photoGallery:', photoGallery)
        };

        fetchSliders();
    }, []);

    const editClickHandler = (id) => {
        router.push(`/admin/photo-gallery/edit/add?Id=${id}`);
    }

    const searchChangeHandler = (value) => {
        if (tempPhotoGallery.length === 0) {
            setTempPhotoGallery(photoGallery);
        }

        if (value.length > 0) {
            const searchSliders = photoGallery.filter(gallery =>
                gallery.title.toLowerCase().includes(value.toLowerCase())
            );

            const exactMatch = searchSliders.filter(gallery =>
                gallery.title.toLowerCase() === value.toLowerCase()
            );
            const otherMatches = searchSliders.filter(gallery =>
                gallery.title.toLowerCase() !== value.toLowerCase()
            );

            setPhotoGallery([...exactMatch, ...otherMatches]);
        } else {
            setPhotoGallery(tempPhotoGallery);
        }
    };

    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}/Gallery/DeleteGallery?id=${id}`);
            if (response.data.succeeded) {
                toast.success('Deleted successfully')
                setPhotoGallery(photoGallery.filter(gallery => gallery.id !== id));
            }
        } catch (error) {
            console.error('Error deleting slider:', error);
        }
    }
    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View Photos</h2>
                </div>
                <div className="view-border-header__add-view"
                onClick={() => router.push("/admin/photo-gallery/add")}
                >
                    <FaPlus />
                    <span>Add New</span>
                </div>
            </div>
            <div className="panel-box mt-3">
                <div className="panel-box-body">
                    <div className="slider-show-content">
                        <div className="slider-show-content__counter">
                            <span>Showing entries</span>
                            <select name="slider-show-entries" id="slider-show-entries">
                                <option value="10">10</option>
                                <option value="20">20</option>
                                <option value="50">50</option>
                                <option value="100">100</option>
                            </select>
                        </div>
                        {
                            isMobile && <div className="slider-show-content__sort">
                                <span>Sort:</span>
                                <select name="slider-show-entries" id="slider-show-entries">
                                    <option value="SL">SL</option>
                                    <option value="Caption">Caption</option>
                                    <option value="ShowOnHome">Photo Show on Home?</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text" placeholder="Search"/>
                        </div>
                    </div>
                    <Table>
                        <Thead>
                            <Tr>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>SL</span>
                                        {!isMobile && <FaSortAmountDown />}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Photo</span>
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Caption</span>
                                        {!isMobile && <FaSortAmountDown />}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Photo Show on Home?</span>
                                        {!isMobile && <FaSortAmountDown />}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Action</span>
                                    </div>
                                </Th>
                            </Tr>
                        </Thead>
                        <Tbody>
                            {photoGallery.map((item, index) => (
                                <Tr key={item.id}>
                                    <Td>
                                        <div className="slider-table-body">
                                            {index + 1}
                                        </div>
                                    </Td>
                                    <Td>
                                        <LazyLoadImage
                                            src={`/${item.photo}`}
                                            alt="Gallery Photo"
                                            className="slider-table-image"
                                        />
                                    </Td>
                                    <Td>
                                        <div className="slider-table-body">
                                            {item.title}
                                        </div>
                                    </Td>
                                    <Td>
                                        <div className="slider-table-body">
                                            {VisibilityPlaceEnum[item.visiblePlace]}
                                        </div>
                                    </Td>
                                    <Td>
                                        <div className="action-edit slider-table-body">
                                            <button className="btn btn-warning me-2" onClick={() => editClickHandler(item.id)}>Edit</button>
                                            <button className="btn btn-danger" onClick={() => deleteClickHandler(item.id)}>Delete</button>
                                        </div>
                                    </Td>
                                </Tr>
                            ))}
                        </Tbody>
                    </Table>


                    <div className="pagination-section">
                        <div className="pagination-information">
                            <span>Showing </span>
                            <span>1</span>
                            <span>to</span>
                            <span>2</span>
                            <span>of</span>
                            <span>2</span>
                            <span>entries</span>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </>
};

export default ViewPhotoGallery;
