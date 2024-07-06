import React, {useEffect, useState} from 'react';
import {useMediaQuery} from "react-responsive";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {Table, Tbody, Td, Th, Thead, Tr} from "react-super-responsive-table";
import {useRouter} from "next/router";
import axios from "axios";
import {toast} from "react-toastify";

const Designation = () => {
    const router = useRouter();
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });
    const [designation, setDesignation] = useState([]);
    const [tempDesignation, setTempDesignation] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Team/GetAllDesignation`);
                if (response.data.succeeded) {

                    var responseValue = response.data.data.designation;
                    setDesignation(responseValue);
                    const filteredKeys = Object.keys(responseValue[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                    setLoading(false);
                }
            } catch (error) {
                setLoading(false);
                console.error('Error fetching sliders:', error);
            } finally {
                setLoading(false);
            }
        };
        fetchSliders();
    }, []);
    const handleSortChange = (event) => {
        const value = event.target.value;

        const sortedCategory = sliders.sort((a, b) => {
            const textA = a[value].toLowerCase();
            const textB = b[value].toLowerCase();
            return textA > textB ? -1 : textA < textB ? 1 : 0;
        });
        console.log('Sorted sliders:', sortedCategory)
        setDesignation( [...sortedCategory]);
    }
    const editClickHandler = (id) => {
        router.push(`/admin/team-member/designation/edit/add?Id=${id}`);
    }
    const searchChangeHandler = (value) => {
        if (tempDesignation.length === 0) {
            setTempDesignation(designation);
        }

        if (value.length > 0) {
            const searchSliders = tempDesignation.filter(designation =>
                designation.title.toLowerCase().includes(value.toLowerCase())
            );

            const exactMatch = searchSliders.filter(designation =>
                designation.title.toLowerCase() === value.toLowerCase()
            );
            const otherMatches = searchSliders.filter(designation =>
                designation.title.toLowerCase() !== value.toLowerCase()
            );

            setDesignation([...exactMatch, ...otherMatches]);
        } else {
            setDesignation(tempDesignation);
        }
    };

    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}Team/DeleteDesignation?Id=${id}`);
            if (response.data.succeeded) {
                toast.success("Designation deleted successfully")
                setDesignation(designation.filter(designation => designation.id !== id));
            }
        } catch (error) {
            console.error('Error deleting designation:', error);
        }
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
                    <h2>View Designation</h2>
                </div>
                <div className="view-border-header__add-view"
                onClick={() => router.push("/admin/team-member/designation/add")}
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
                                    <option value="DesignationName">Designation Name</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text"
                                   placeholder="Search"
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
                                <Th className="table-body-col-header-45">
                                    <div className="slider-table-head">
                                        <span>Designation Name</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th className="w-25">
                                    <div className="slider-table-head">
                                        <span>Action</span>
                                    </div>
                                </Th>
                            </Tr>
                        </Thead>
                        <Tbody>
                            {
                                designation?.map((designationPiece,index)=>(
                                    <Tr key={designationPiece.id}>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {index + 1}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {designationPiece.title}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="action-edit slider-table-body">
                                                <button className="btn btn-warning me-2"
                                                        onClick={() => editClickHandler(designationPiece.id)}
                                                >Edit</button>
                                                <button className="btn btn-danger"
                                                        onClick={() => deleteClickHandler(designationPiece.id)}
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

export default Designation;
