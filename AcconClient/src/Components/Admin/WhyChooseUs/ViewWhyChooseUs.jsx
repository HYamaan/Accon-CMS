import React, {useEffect, useState} from 'react';
import {useMediaQuery} from "react-responsive";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {Table, Tbody, Td, Th, Thead, Tr} from "react-super-responsive-table";
import {useRouter} from "next/router";
import axios from "axios";
import {toast} from "react-toastify";

const ViewWhyChooseUs = () => {
    const router = useRouter();
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });

    const [chooseUs, setChooseUs] = useState([]);
    const [tempChooseUs, setTempChooseUs] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/WhyChooseUs/GetWhyChooseList`);
                if (response.data.succeeded) {
                    var data = response.data.data.whyChoose;
                    setChooseUs(data);
                    const filteredKeys = Object.keys(data[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                }
            } catch (error) {
                console.error('Error fetching chooseUs:', error);
            } finally {
                setLoading(false);
            }

        };

        fetchSliders();
    }, []);

    const searchChangeHandler = (value) => {
        if (tempChooseUs.length === 0) {
            setTempChooseUs(chooseUs);
        }

        if (value.length > 0) {
            const searchSliders = chooseUs.filter(chooseUs =>
                chooseUs.title.toLowerCase().includes(value.toLowerCase())
            );

            const exactMatch = searchSliders.filter(chooseUs =>
                chooseUs.title.toLowerCase() === value.toLowerCase()
            );
            const otherMatches = searchSliders.filter(chooseUs =>
                chooseUs.title.toLowerCase() !== value.toLowerCase()
            );

            setChooseUs([...exactMatch, ...otherMatches]);
        } else {
            setChooseUs(tempChooseUs);
        }
    };
    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}/WhyChooseUs/DeleteChooseUs?Id=${id}`);
            if (response.data.succeeded) {
                toast.success("chooseUs deleted successfully")
                setChooseUs(chooseUs.filter(chooseUs => chooseUs.id !== id));
            }
        } catch (error) {
            toast.error("Error deleting chooseUs")
            console.error('Error deleting slider:', error);
        }
    }
    const editClickHandler = (id) => {
        router.push(`/admin/why-choose-us/edit/add?Id=${id}`);
    }
    if (loading) {
        return (
            <div className="content-wrapper">
                <div>Loading...</div>
            </div>
        );
    }

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View Partners</h2>
                </div>
                <div className="view-border-header__add-view"
                onClick={() => router.push("/admin/why-choose-us/add")}
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
                                    <option value="Title">Title</option>
                                    <option value="Content">Content</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text" placeholder="Search"
                                   onChange={(event) => searchChangeHandler(event.target.value)}

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
                                        <span>Icon</span>
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Title</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th className="table-body-col-header-45">
                                    <div className="slider-table-head">
                                        <span>Content</span>
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
                                chooseUs?.map((sum,index) =>(
                                    <Tr key={sum.id}>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {index + 1}
                                            </div>
                                        </Td>
                                        <Td>
                                            <LazyLoadImage
                                                src={`/${sum.photo}`}
                                                alt={sum.photo}
                                                className="slider-table-image"
                                            />
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {sum.title}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {sum.content}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="action-edit slider-table-body">
                                                <button className="btn btn-warning me-2"
                                                        onClick={() => editClickHandler(sum.id)}
                                                >Edit</button>
                                                <button className="btn btn-danger"
                                                        onClick={() => deleteClickHandler(sum.id)}
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

export default ViewWhyChooseUs;
