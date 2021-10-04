using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.Partner
{
	public class Partner
	{
		private long _pk_partnerid;
		public long Pk_partnerid
		{
			get { return _pk_partnerid; }
			set { _pk_partnerid = value; }
		}

		private long _fk_companyid;
		public long Fk_companyid
		{
			get { return _fk_companyid; }
			set { _fk_companyid = value; }
		}

		private string _par_name;
		public string Par_name
		{
			get { return _par_name; }
			set { _par_name = value; }
		}

		private string _par_mobile;
		public string Par_mobile
		{
			get { return _par_mobile; }
			set { _par_mobile = value; }
		}

		private DateTime? _par_passport_exp;
		public DateTime? Par_passport_exp
		{
			get { return _par_passport_exp; }
			set { _par_passport_exp = value; }
		}

		private DateTime? _par_insurance_exp;
		public DateTime? Par_insurance_exp
		{
			get { return _par_insurance_exp; }
			set { _par_insurance_exp = value; }
		}

		private DateTime? _par_visa_exp;
		public DateTime? Par_visa_exp
		{
			get { return _par_visa_exp; }
			set { _par_visa_exp = value; }
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

	}
}