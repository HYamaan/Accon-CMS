import React, {useEffect, useRef, useState} from 'react';
import { Table, Thead, Tbody, Tr, Th, Td } from 'react-super-responsive-table';
import 'react-super-responsive-table/dist/SuperResponsiveTableStyle.css';
import { FaArrowAltCircleRight, FaPlus, FaSortAmountDown } from "react-icons/fa";
import { LazyLoadImage } from "react-lazy-load-image-component";
import { useMediaQuery } from "react-responsive";
import { useRouter } from "next/router";
import axios from "axios";
import {toast} from "react-toastify";

const ViewSlider = () => {
    const router = useRouter();
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });
    const [sliders, setSliders] = useState([]);
    const [tempSliders, setTempSliders] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Slider/GetSlider`);
                if (response.data.succeeded) {
                    setSliders(response.data.data.sliders);
                    const filteredKeys = Object.keys(response.data.data.sliders[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                }
            } catch (error) {
                console.error('Error fetching sliders:', error);
            } finally {
                setLoading(false);
            }
            console.log('Sliders:', sliders)
        };

        fetchSliders();
    }, []);

    const handleSortChange = (event) => {
        const value = event.target.value;

        const sortedSliders = sliders.sort((a, b) => {
            const textA = a[value].toLowerCase();
            const textB = b[value].toLowerCase();
            return textA > textB ? -1 : textA < textB ? 1 : 0;
        });
        console.log('Sorted sliders:', sortedSliders)
        setSliders( [...sortedSliders]);
    }


    const editClickHandler = (id) => {
        router.push(`/admin/slider/edit/add?Id=${id}`);
    }

    const searchChangeHandler = (value) => {
        if (tempSliders.length === 0) {
            setTempSliders(sliders);
        }

        if (value.length > 0) {
            const searchSliders = sliders.filter(slider =>
                slider.heading.toLowerCase().includes(value.toLowerCase())
            );

            const exactMatch = searchSliders.filter(slider =>
                slider.heading.toLowerCase() === value.toLowerCase()
            );
            const otherMatches = searchSliders.filter(slider =>
                slider.heading.toLowerCase() !== value.toLowerCase()
            );

            setSliders([...exactMatch, ...otherMatches]);
        } else {
            setSliders(tempSliders);
        }
    };

    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}/Slider/DeleteSlider?Id=${id}`);
            if (response.data.succeeded) {
              toast.success("Slider deleted successfully")
                setSliders(sliders.filter(slider => slider.id !== id));
            }
        } catch (error) {
            console.error('Error deleting slider:', error);
        }
    }

    return (
        <>
            <div className="content-wrapper">
                <div className="view-border-header">
                    <div className="board-header">
                        <FaArrowAltCircleRight />
                        <h2>View Sliders</h2>
                    </div>
                    <div className="view-border-header__add-view"
                         onClick={() => router.push("/admin/slider/add")}
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
                                    <select name="slider-show-entries" id="slider-show-entries" onChange={handleSortChange}>
                                        {keys.map(key => (
                                            <option key={key} value={key}>{key}</option>
                                        ))}
                                    </select>
                                </div>
                            }
                            <div className="slider-show-content__search">
                                <span>Search:</span>
                                <input
                                    type="text"
                                    placeholder="Search"
                                    onChange={(event)=>searchChangeHandler(event.target.value)}
                                />
                            </div>
                        </div>
                        <Table>
                            <Thead>
                                <Tr>
                                    <Th>
                                        <div className="slider-table-head">
                                            <span>SL</span>
                                            {!isMobile && <FaSortAmountDown/>}
                                        </div>
                                    </Th>
                                    <Th>
                                        <div className="slider-table-head">
                                            <span>Photo</span>
                                        </div>
                                    </Th>
                                    <Th>
                                        <div className="slider-table-head">
                                            <span>Heading</span>
                                            {!isMobile && <FaSortAmountDown />}
                                        </div>
                                    </Th>
                                    <Th>
                                        <div className="slider-table-head">
                                            <span>Button1 Text</span>
                                            {!isMobile && <FaSortAmountDown />}
                                        </div>
                                    </Th>
                                    <Th>
                                        <div className="slider-table-head">
                                            <span>Button1 URL</span>
                                            {!isMobile && <FaSortAmountDown />}
                                        </div>
                                    </Th>
                                    <Th>
                                        <div className="slider-table-head">
                                            <span>Button2 Text</span>
                                            {!isMobile && <FaSortAmountDown />}
                                        </div>
                                    </Th>
                                    <Th>
                                        <div className="slider-table-head">
                                            <span>Button2 URL</span>
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
                                {sliders.map((slider, index) => (
                                    <Tr key={index}>
                                        <Td>
                                            <div className="slider-table-body">
                                                {index + 1}
                                            </div>
                                        </Td>
                                        <Td>
                                            <LazyLoadImage
                                                src={`/${slider.path}`}
                                                alt={`slider-${index + 1}`}
                                                effect="blur"
                                                className="slider-table-image"
                                            />
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body">
                                                {slider.heading}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body">
                                                {slider.button1Text}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body">
                                                {slider.button1Link}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body">
                                                {slider.button2Text}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body">
                                                {slider.button2Link}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="action-edit slider-table-body">
                                                <button className="btn btn-warning me-2" onClick={()=>editClickHandler(slider.id)}>Edit</button>
                                                <button className="btn btn-danger" onClick={()=>deleteClickHandler(slider.id)}>Delete</button>
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
    );
};

export default ViewSlider;
