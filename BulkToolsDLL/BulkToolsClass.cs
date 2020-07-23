/* Title:           Bulk Tools Class
 * Date:            11-14-18
 * Author:          Terry Holmes
 * 
 * Description:     This class is used for bulk tools */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace BulkToolsDLL
{
    public class BulkToolsClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        BulkToolsDataSet aBulkToolsDataSet;
        BulkToolsDataSetTableAdapters.bulktoolsTableAdapter aBulkToolsTableAdapter;

        InsertBulkToolsEntryTableAdapters.QueriesTableAdapter aInsertBulkToolsTableAdapter;

        SignInBulkToolEntryTableAdapters.QueriesTableAdapter aSignInBulkToolTableAdapter;

        FindBulkToolsCurrentlyAssignedToEmployeeDataSet aFindBulkToolsCurrentlyAssignedToEmployeeDataSet;
        FindBulkToolsCurrentlyAssignedToEmployeeDataSetTableAdapters.FindBulkToolsCurrentlyAssignedToEmployeeTableAdapter aFindBulkToolsCurrentlyAssignedToEmployeeTableAdapter;

        FindAllBulkToolsCurrentlyAssignedDataSet aFindAllBulkToolsCurrentAssignedDataSet;
        FindAllBulkToolsCurrentlyAssignedDataSetTableAdapters.FindAllBulkToolsCurrentlyAssignedTableAdapter aFindAllBulkToolsCurrentlyAssignedTableAdapter;

        UpdateBulkToolsQuantityEntryTableAdapters.QueriesTableAdapter aUpdateBulkToolsQuantityTableAdapter;

        FindBulkToolsByTransactionIDDataSet aFindBulkToolsbyTransactionIDDataSet;
        FindBulkToolsByTransactionIDDataSetTableAdapters.FindBulkToolsByTransactionIDTableAdapter aFindBulkToolsByTransactionIDTableAdapter;

        FindBulkToolsByDateMatchDataSet aFindBulkToolsByDateMatchDataSet;
        FindBulkToolsByDateMatchDataSetTableAdapters.FindBulkToolsByDateMatchTableAdapter aFindBulkToolsbyDateMatchTableAdapter;

        public FindBulkToolsByDateMatchDataSet FindBulkToolsByDateMatch(DateTime datSignOutDate)
        {
            try
            {
                aFindBulkToolsByDateMatchDataSet = new FindBulkToolsByDateMatchDataSet();
                aFindBulkToolsbyDateMatchTableAdapter = new FindBulkToolsByDateMatchDataSetTableAdapters.FindBulkToolsByDateMatchTableAdapter();
                aFindBulkToolsbyDateMatchTableAdapter.Fill(aFindBulkToolsByDateMatchDataSet.FindBulkToolsByDateMatch, datSignOutDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Bulk Tools Class // Find Bulk Tools By Date Match " + Ex.Message);
            }

            return aFindBulkToolsByDateMatchDataSet;
        }
        public FindBulkToolsByTransactionIDDataSet FindBulkToolsByTransactionID(int intTransactionID)
        {
            try
            {
                aFindBulkToolsbyTransactionIDDataSet = new FindBulkToolsByTransactionIDDataSet();
                aFindBulkToolsByTransactionIDTableAdapter = new FindBulkToolsByTransactionIDDataSetTableAdapters.FindBulkToolsByTransactionIDTableAdapter();
                aFindBulkToolsByTransactionIDTableAdapter.Fill(aFindBulkToolsbyTransactionIDDataSet.FindBulkToolsByTransactionID, intTransactionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Bulk Tools Class // Find Bulk Tools By Transaction ID " + Ex.Message);
            }

            return aFindBulkToolsbyTransactionIDDataSet;
        }
        public bool UpdateBulkToolsQuantity(int intTransactionID, int intQuantity)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateBulkToolsQuantityTableAdapter = new UpdateBulkToolsQuantityEntryTableAdapters.QueriesTableAdapter();
                aUpdateBulkToolsQuantityTableAdapter.UpdateBulkToolsQuantity(intTransactionID, intQuantity);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Bulk Tools Class // UPdate Bulk Tools Quantity " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FindAllBulkToolsCurrentlyAssignedDataSet FindAllBulkToolsCurrentlyAssigned()
        {
            try
            {
                aFindAllBulkToolsCurrentAssignedDataSet = new FindAllBulkToolsCurrentlyAssignedDataSet();
                aFindAllBulkToolsCurrentlyAssignedTableAdapter = new FindAllBulkToolsCurrentlyAssignedDataSetTableAdapters.FindAllBulkToolsCurrentlyAssignedTableAdapter();
                aFindAllBulkToolsCurrentlyAssignedTableAdapter.Fill(aFindAllBulkToolsCurrentAssignedDataSet.FindAllBulkToolsCurrentlyAssigned);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Bulk Tools Class // Find All Bulk Tools Currently Assigned " + Ex.Message);
            }

            return aFindAllBulkToolsCurrentAssignedDataSet;
        }
        public FindBulkToolsCurrentlyAssignedToEmployeeDataSet FindBulkToolsCurrentlyAssignedToEmployee(int intEmployeeID)
        {
            try
            {
                aFindBulkToolsCurrentlyAssignedToEmployeeDataSet = new FindBulkToolsCurrentlyAssignedToEmployeeDataSet();
                aFindBulkToolsCurrentlyAssignedToEmployeeTableAdapter = new FindBulkToolsCurrentlyAssignedToEmployeeDataSetTableAdapters.FindBulkToolsCurrentlyAssignedToEmployeeTableAdapter();
                aFindBulkToolsCurrentlyAssignedToEmployeeTableAdapter.Fill(aFindBulkToolsCurrentlyAssignedToEmployeeDataSet.FindBulkToolsCurrentlyAssignedToEmployee, intEmployeeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Bulk Tools Class // Find Bulk Tools Currently Assigned To Employee " + Ex.Message);
            }

            return aFindBulkToolsCurrentlyAssignedToEmployeeDataSet;
        }
        public bool SignInBulkTool(int intTransactionID, int intSignInEmployeeID)
        {
            bool blnFatalError = false;

            try
            {
                aSignInBulkToolTableAdapter = new SignInBulkToolEntryTableAdapters.QueriesTableAdapter();
                aSignInBulkToolTableAdapter.SignBulkToolIn(intTransactionID, DateTime.Now, intSignInEmployeeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Bulk Tools Class // Sign In Bulk Tools " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertBulkTools(int intEmployeeID, int intCategoryID, int intQuantity, DateTime datTransactionDate, int intAssignEmployeeID, string strIssueNotes)
        {
            bool blnFatalError = false;

            try
            {
                aInsertBulkToolsTableAdapter = new InsertBulkToolsEntryTableAdapters.QueriesTableAdapter();
                aInsertBulkToolsTableAdapter.InsertBulkTools(intEmployeeID, intCategoryID, intQuantity, datTransactionDate, intAssignEmployeeID, strIssueNotes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Bulk Tools Class // Insert Bulk Tools " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public BulkToolsDataSet GetBulkToolsInfo()
        {
            try
            {
                aBulkToolsDataSet = new BulkToolsDataSet();
                aBulkToolsTableAdapter = new BulkToolsDataSetTableAdapters.bulktoolsTableAdapter();
                aBulkToolsTableAdapter.Fill(aBulkToolsDataSet.bulktools);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Bulk Tools Class // Get Bulk Tools Info " + Ex.Message);
            }

            return aBulkToolsDataSet;
        }
        public void UpdateBulkToolsDB(BulkToolsDataSet aBulkToolsDataSet)
        {
            try
            {
                aBulkToolsTableAdapter = new BulkToolsDataSetTableAdapters.bulktoolsTableAdapter();
                aBulkToolsTableAdapter.Update(aBulkToolsDataSet.bulktools);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Bulk Tools Class // Update Bulk Tools DB " + Ex.Message);
            }
        }
    }
}
