using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.Company
{
	public class Company
	{
		private long _pk_companyid;
		public long Pk_companyid
		{
			get { return _pk_companyid; }
			set { _pk_companyid = value; }
		}

		private string _comp_name;
		public string Comp_name
		{
			get { return _comp_name; }
			set { _comp_name = value; }
		}

		private string _comp_address;
		public string Comp_address
		{
			get { return _comp_address; }
			set { _comp_address = value; }
		}

		private string _comp_phone;
		public string Comp_phone
		{
			get { return _comp_phone; }
			set { _comp_phone = value; }
		}

		private DateTime? _comp_trade_license_exp;
		public DateTime? Comp_trade_license_exp
		{
			get { return _comp_trade_license_exp; }
			set { _comp_trade_license_exp = value; }
		}

		private DateTime? _comp_immigration_exp;
		public DateTime? Comp_immigration_exp
		{
			get { return _comp_immigration_exp; }
			set { _comp_immigration_exp = value; }
		}

		private DateTime? _Comp_import_code_exp;
		public DateTime? Comp_import_code_exp
		{
			get { return _Comp_import_code_exp; }
			set { _Comp_import_code_exp = value; }
		}

		private DateTime? _comp_insurance_exp;
		public DateTime? Comp_insurance_exp
		{
			get { return _comp_insurance_exp; }
			set { _comp_insurance_exp = value; }
		}

		private string _notes;
		public string Notes
		{
			get { return _notes; }
			set { _notes = value; }
		}

		private bool? _is_active;
		public bool? Is_active
		{
			get { return _is_active; }
			set { _is_active = value; }
		}

		private bool? _is_deleted;
		public bool? Is_deleted
		{
			get { return _is_deleted; }
			set { _is_deleted = value; }
		}

		private long _fk_created_by;
		public long Fk_created_by
		{
			get { return _fk_created_by; }
			set { _fk_created_by = value; }
		}

		private long _fk_modified_by;
		public long Fk_modified_by
		{
			get { return _fk_modified_by; }
			set { _fk_modified_by = value; }
		}

		private DateTime _created_date;
		public DateTime Created_date
		{
			get { return _created_date; }
			set { _created_date = value; }
		}

		private DateTime _modified_date;
		public DateTime Modified_date
		{
			get { return _modified_date; }
			set { _modified_date = value; }
		}

		private string _comp_email;
		public string Comp_email
		{
			get { return _comp_email; }
			set { _comp_email = value; }
		}

		private string _comp_contact_person;
		public string Comp_contact_person
		{
			get { return _comp_contact_person; }
			set { _comp_contact_person = value; }
		}

		private string _comp_cp_phone;
		public string Comp_cp_phone
		{
			get { return _comp_cp_phone; }
			set { _comp_cp_phone = value; }
		}
	}
}