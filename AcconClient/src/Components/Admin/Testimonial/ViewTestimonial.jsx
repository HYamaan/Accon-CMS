import React, {useEffect, useState} from 'react';
import {useMediaQuery} from "react-responsive";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {Table, Tbody, Td, Th, Thead, Tr} from "react-super-responsive-table";
import {useRouter} from "next/router";
import axios from "axios";
import {toast} from "react-toastify";

const ViewTestimonial = () => {
    const router = useRouter();
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });

    const [testimonial, setTestimonial] = useState([]);
    const [tempTestimonial, setTempTestimonial] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Testimonial/GetAllTestimonials`);
                if (response.data.succeeded) {
                    const responseData = response.data.data.testimonials;
                    setTestimonial(responseData);
                    const filteredKeys = Object.keys(responseData[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                }
            } catch (error) {
                console.error('Error fetching testimonial:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchSliders();
    }, []);

    const searchChangeHandler = (value) => {
        if (tempTestimonial.length === 0) {
            setTempTestimonial(testimonial);
        }
        if (value.length > 0) {
            const searchSliders = testimonial.filter(csx =>
                csx.name.toLowerCase().includes(value.toLowerCase())
            );

            const exactMatch = searchSliders.filter(csx =>
                csx.name.toLowerCase() === value.toLowerCase()
            );
            const otherMatches = searchSliders.filter(csx =>
                csx.name.toLowerCase() !== value.toLowerCase()
            );

            setTestimonial([...exactMatch, ...otherMatches]);
        } else {
            setTestimonial(tempTestimonial);
        }
    };

    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}/Testimonial/DeleteTestimonial?Id=${id}`);
            if (response.data.succeeded) {
                toast.success("testimonial deleted successfully")
                setTestimonial(testimonial.filter(testimonial => testimonial.id !== id));
            }
        } catch (error) {
            console.error('Error deleting testimonial:', error);
        }
    }
    const editClickHandler = (id) => {
        router.push(`/admin/testimonial/edit/add?Id=${id}`);
    }

    if (loading) {
        return <div>Loading...</div>
    }
    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View Testimonial</h2>
                </div>
                <div className="view-border-header__add-view"
                onClick={() => router.push("/admin/testimonial/add")}
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
                                    <option value="Name">Name</option>
                                    <option value="Designation">Designation</option>
                                    <option value="Company">Company</option>
                                    <option value="Comment">Comment</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text" placeholder="Search"
                                      onChange={(e) => searchChangeHandler(e.target.value)}
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
                                        <span>Name</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Designation</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Company</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th className="table-body-col-header-45">
                                    <div className="slider-table-head">
                                        <span>Comment</span>
                                        {!isMobile && <FaSortAmountDown/>}
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
                            {
                                testimonial.map((testimonial, index) => (
                                    <Tr key={testimonial.id}>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {index + 1}
                                            </div>
                                        </Td>
                                        <Td>
                                            <LazyLoadImage
                                                src={`/${testimonial.photo}`}
                                                alt={testimonial.photo}
                                                className="slider-table-image"
                                            />
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {testimonial.name}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {testimonial.designation}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {testimonial.company}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {testimonial.comment}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="action-edit slider-table-body">
                                                <button className="btn btn-warning me-2"
                                                        onClick={() => editClickHandler(testimonial.id)}
                                                >Edit</button>
                                                <button className="btn btn-danger"
                                                        onClick={() => deleteClickHandler(testimonial.id)}
                                                >Delete</button>
                                            </div>
                                        </Td>
                                    </Tr>
                                ))
                            }
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

export default ViewTestimonial;
