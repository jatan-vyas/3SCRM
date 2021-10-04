using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.Partner
{
    public class PartnerFamily
    {
		private long _pk_familyid;
		public long Pk_familyid
		{
			get { return _pk_familyid; }
			set { _pk_familyid = value; }
		}

		private long _fk_partnerid;
		public long Fk_partnerid
		{
			get { return _fk_partnerid; }
			set { _fk_partnerid = value; }
		}

		private string _fml_name;
		public string Fml_name
		{
			get { return _fml_name; }
			set { _fml_name = value; }
		}
		private string _par_name;
		public string Par_name
		{
			get { return _par_name; }
			set { _par_name = value; }
		}
		private string _fml_mobile;
		public string Fml_mobile
		{
			get { return _fml_mobile; }
			set { _fml_mobile = value; }
		}
		private string _par_mobile;
		public string Par_mobile
		{
			get { return _par_mobile; }
			set { _par_mobile = value; }
		}
		private string _fml_relation;
		public string Fml_relation
		{
			get { return _fml_relation; }
			set { _fml_relation = value; }
		}

		private DateTime? _Fml_passport_exp;
		public DateTime? Fml_passport_exp
		{
			get { return _Fml_passport_exp; }
			set { _Fml_passport_exp = value; }
		}

		private DateTime? _fml_insurance_exp;
		public DateTime? Fml_insurance_exp
		{
			get { return _fml_insurance_exp; }
			set { _fml_insurance_exp = value; }
		}

		private DateTime? _fml_visa_exp;
		public DateTime? Fml_visa_exp
		{
			get { return _fml_visa_exp; }
			set { _fml_visa_exp = value; }
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